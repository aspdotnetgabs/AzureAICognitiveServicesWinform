using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Newtonsoft.Json;

namespace AICognitiveServicesApp
{
	public partial class MainForm : Form
	{		
		// Add your Azure Computer Vision subscription key and endpoint
		// Get your 7-day trial API key here:  https://azure.microsoft.com/en-us/try/cognitive-services/
		string subscriptionKey = "PUT YOUR API KEY HERE";
		string endpoint = "PUT YOUR COMPUTER VISION API ENDPOINT HERE"; // https://westcentralus.api.cognitive.microsoft.com
		string imageFilePath;
		
		public MainForm()
		{
			InitializeComponent();		
		}
       
		// AUTHENTICATE. Creates a Computer Vision client
		private static ComputerVisionClient Authenticate(string endpoint, string key)
		{
			var client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(key)) 
			{
				Endpoint = endpoint
			};
            
			return client;
		}
		
		void BtnBrowseClick(object sender, EventArgs e)
		{
			var fileDialog = new OpenFileDialog();			
			fileDialog.Title = "Browse photo";
			fileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";

			if (fileDialog.ShowDialog() == DialogResult.OK) 
			{
				imageFilePath = fileDialog.FileName;				
				pictureBox1.Image = Image.FromFile(imageFilePath);		
				btnAnalyzeImage.Enabled = true;
			}
		}
		
		async void BtnAnalyzeImageClick(object sender, EventArgs e)
		{
			byte[] imgdata = File.ReadAllBytes(imageFilePath).Resize();
			var ms = new MemoryStream(imgdata);
			
			// Authenticate
			ComputerVisionClient client = Authenticate(endpoint, subscriptionKey);
			
			// Creating a list that defines the features to be extracted from the image. 
			List<VisualFeatureTypes> features = new List<VisualFeatureTypes>() 
			{
				VisualFeatureTypes.Categories, 
				VisualFeatureTypes.Description
			};
                
			// Analyze the image
			ImageAnalysis results = await client.AnalyzeImageInStreamAsync(ms, features);
			
			// Display in results
			txtResultDesc.Text = CreateDescription(results);
			txtResultJson.Text = JsonConvert.SerializeObject(results);			
		}
		
		private string CreateDescription(ImageAnalysis imgAnalysis)
		{
			var imageDesc = string.Empty;
			foreach (var category in imgAnalysis.Categories) 
			{
				if (category.Detail != null && category.Detail.Landmarks != null) 
				{
					foreach (var landmark in category.Detail.Landmarks) 
					{
						imageDesc += "I found a landmark " + landmark.Name + ". ";
					}
				}
                
				if (category.Detail != null && category.Detail.Celebrities != null) 
				{
					foreach (var celeb in category.Detail.Celebrities) 
					{
						imageDesc += celeb.Name + " is in this photo. ";
					}
				}              
			}
            
			foreach (var caption in imgAnalysis.Description.Captions) 
			{
				imageDesc += "In summary, the photo is about " + caption.Text + ".";
			}        

			return imageDesc;
		}
		
	}
}
