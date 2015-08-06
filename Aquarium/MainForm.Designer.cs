namespace Aquarium
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.aquariumControl = new Aquarium.Controls.AquariumControl();
			this.SuspendLayout();
			// 
			// aquariumControl
			// 
			this.aquariumControl.BackColor = System.Drawing.Color.LightBlue;
			this.aquariumControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.aquariumControl.Location = new System.Drawing.Point(0, 0);
			this.aquariumControl.Name = "aquariumControl";
			this.aquariumControl.Size = new System.Drawing.Size(784, 447);
			this.aquariumControl.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 447);
			this.Controls.Add(this.aquariumControl);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "MainForm";
			this.Text = "Aquarium";
			this.ResumeLayout(false);

		}

		#endregion

		private Controls.AquariumControl aquariumControl;
	}
}

