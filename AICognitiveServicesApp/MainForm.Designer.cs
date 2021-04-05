/*
 * Created by SharpDevelop.
 * User: Gabs
 * Date: 3/7/2021
 * Time: 2:21 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AICognitiveServicesApp
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.Button btnAnalyzeImage;
		private System.Windows.Forms.TextBox txtResultDesc;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TextBox txtResultJson;
		private System.Windows.Forms.Button btnExtractTextFromImage;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.btnAnalyzeImage = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.txtResultDesc = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.txtResultJson = new System.Windows.Forms.TextBox();
			this.btnExtractTextFromImage = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Location = new System.Drawing.Point(73, 81);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(640, 360);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// btnBrowse
			// 
			this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnBrowse.Location = new System.Drawing.Point(73, 21);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(172, 43);
			this.btnBrowse.TabIndex = 1;
			this.btnBrowse.Text = "Browse Photo";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.BtnBrowseClick);
			// 
			// btnAnalyzeImage
			// 
			this.btnAnalyzeImage.Enabled = false;
			this.btnAnalyzeImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAnalyzeImage.Location = new System.Drawing.Point(359, 21);
			this.btnAnalyzeImage.Name = "btnAnalyzeImage";
			this.btnAnalyzeImage.Size = new System.Drawing.Size(172, 43);
			this.btnAnalyzeImage.TabIndex = 2;
			this.btnAnalyzeImage.Text = "Analyze Photo";
			this.btnAnalyzeImage.UseVisualStyleBackColor = true;
			this.btnAnalyzeImage.Click += new System.EventHandler(this.BtnAnalyzeImageClick);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(73, 447);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(640, 100);
			this.tabControl1.TabIndex = 3;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.txtResultDesc);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(632, 74);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Description";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// txtResultDesc
			// 
			this.txtResultDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtResultDesc.Location = new System.Drawing.Point(0, 0);
			this.txtResultDesc.Multiline = true;
			this.txtResultDesc.Name = "txtResultDesc";
			this.txtResultDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtResultDesc.Size = new System.Drawing.Size(632, 74);
			this.txtResultDesc.TabIndex = 4;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.txtResultJson);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(632, 74);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "JSON";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// txtResultJson
			// 
			this.txtResultJson.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtResultJson.Location = new System.Drawing.Point(0, 0);
			this.txtResultJson.Multiline = true;
			this.txtResultJson.Name = "txtResultJson";
			this.txtResultJson.Size = new System.Drawing.Size(632, 74);
			this.txtResultJson.TabIndex = 5;
			// 
			// btnExtractTextFromImage
			// 
			this.btnExtractTextFromImage.Enabled = false;
			this.btnExtractTextFromImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnExtractTextFromImage.Location = new System.Drawing.Point(537, 21);
			this.btnExtractTextFromImage.Name = "btnExtractTextFromImage";
			this.btnExtractTextFromImage.Size = new System.Drawing.Size(172, 43);
			this.btnExtractTextFromImage.TabIndex = 4;
			this.btnExtractTextFromImage.Text = "Extract Text";
			this.btnExtractTextFromImage.UseVisualStyleBackColor = true;
			this.btnExtractTextFromImage.Click += new System.EventHandler(this.BtnExtractTextFromImageClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 561);
			this.Controls.Add(this.btnExtractTextFromImage);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.btnAnalyzeImage);
			this.Controls.Add(this.btnBrowse);
			this.Controls.Add(this.pictureBox1);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Computer Vision - AI Cognitive Services";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.ResumeLayout(false);

		}
	}
}
