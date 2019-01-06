namespace GridMazeSolverApplication.View
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.MazeContainer = new System.Windows.Forms.GroupBox();
            this.GenerateMazeButton = new System.Windows.Forms.Button();
            this.ShowSolutionButton = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Maze Options";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(13, 140);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Solution Options";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ShowSolutionButton);
            this.groupBox3.Controls.Add(this.GenerateMazeButton);
            this.groupBox3.Location = new System.Drawing.Point(13, 265);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 100);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Program Options";
            // 
            // MazeContainer
            // 
            this.MazeContainer.Location = new System.Drawing.Point(241, 13);
            this.MazeContainer.Name = "MazeContainer";
            this.MazeContainer.Size = new System.Drawing.Size(492, 425);
            this.MazeContainer.TabIndex = 3;
            this.MazeContainer.TabStop = false;
            this.MazeContainer.Text = "Maze";
            // 
            // GenerateMazeButton
            // 
            this.GenerateMazeButton.Location = new System.Drawing.Point(85, 20);
            this.GenerateMazeButton.Name = "GenerateMazeButton";
            this.GenerateMazeButton.Size = new System.Drawing.Size(109, 28);
            this.GenerateMazeButton.TabIndex = 0;
            this.GenerateMazeButton.Text = "Generate Maze";
            this.GenerateMazeButton.UseVisualStyleBackColor = true;
            // 
            // ShowSolutionButton
            // 
            this.ShowSolutionButton.Location = new System.Drawing.Point(85, 54);
            this.ShowSolutionButton.Name = "ShowSolutionButton";
            this.ShowSolutionButton.Size = new System.Drawing.Size(109, 28);
            this.ShowSolutionButton.TabIndex = 1;
            this.ShowSolutionButton.Text = "Show Solution";
            this.ShowSolutionButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 450);
            this.Controls.Add(this.MazeContainer);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button ShowSolutionButton;
        private System.Windows.Forms.Button GenerateMazeButton;
        private System.Windows.Forms.GroupBox MazeContainer;
    }
}