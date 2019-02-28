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
            this.MazeOptions_UIGroupbox = new System.Windows.Forms.GroupBox();
            this.SetMazeType_UIComboBox = new System.Windows.Forms.ComboBox();
            this.MazeType_UILabel = new System.Windows.Forms.Label();
            this.MazeDimension_Label = new System.Windows.Forms.Label();
            this.MazeDimensions_UINumeric = new System.Windows.Forms.NumericUpDown();
            this.GenerateMaze_UIButton = new System.Windows.Forms.Button();
            this.SolutionOptions_UIGroupbox = new System.Windows.Forms.GroupBox();
            this.SetAlgorithm_Label = new System.Windows.Forms.Label();
            this.SetAlgorithm_UICombobox = new System.Windows.Forms.ComboBox();
            this.ProgramOptions_UIGroupbox = new System.Windows.Forms.GroupBox();
            this.CancelSolveMaze_UIButton = new System.Windows.Forms.Button();
            this.SolveMaze_UIButton = new System.Windows.Forms.Button();
            this.MazeContainer_UIGroupbox = new System.Windows.Forms.GroupBox();
            this.Grid_UIVisualGrid = new GridMazeSolverApplication.CustomControls.VisualGrid();
            this.chkShowAlgorithGraphics = new System.Windows.Forms.CheckBox();
            this.MazeOptions_UIGroupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MazeDimensions_UINumeric)).BeginInit();
            this.SolutionOptions_UIGroupbox.SuspendLayout();
            this.ProgramOptions_UIGroupbox.SuspendLayout();
            this.MazeContainer_UIGroupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MazeOptions_UIGroupbox
            // 
            this.MazeOptions_UIGroupbox.Controls.Add(this.SetMazeType_UIComboBox);
            this.MazeOptions_UIGroupbox.Controls.Add(this.MazeType_UILabel);
            this.MazeOptions_UIGroupbox.Controls.Add(this.MazeDimension_Label);
            this.MazeOptions_UIGroupbox.Controls.Add(this.MazeDimensions_UINumeric);
            this.MazeOptions_UIGroupbox.Controls.Add(this.GenerateMaze_UIButton);
            this.MazeOptions_UIGroupbox.Location = new System.Drawing.Point(13, 13);
            this.MazeOptions_UIGroupbox.Name = "MazeOptions_UIGroupbox";
            this.MazeOptions_UIGroupbox.Size = new System.Drawing.Size(222, 144);
            this.MazeOptions_UIGroupbox.TabIndex = 0;
            this.MazeOptions_UIGroupbox.TabStop = false;
            this.MazeOptions_UIGroupbox.Text = "Maze Options";
            // 
            // SetMazeType_UIComboBox
            // 
            this.SetMazeType_UIComboBox.FormattingEnabled = true;
            this.SetMazeType_UIComboBox.Location = new System.Drawing.Point(105, 63);
            this.SetMazeType_UIComboBox.Name = "SetMazeType_UIComboBox";
            this.SetMazeType_UIComboBox.Size = new System.Drawing.Size(109, 21);
            this.SetMazeType_UIComboBox.TabIndex = 5;
            // 
            // MazeType_UILabel
            // 
            this.MazeType_UILabel.AutoSize = true;
            this.MazeType_UILabel.Location = new System.Drawing.Point(7, 63);
            this.MazeType_UILabel.Name = "MazeType_UILabel";
            this.MazeType_UILabel.Size = new System.Drawing.Size(60, 13);
            this.MazeType_UILabel.TabIndex = 4;
            this.MazeType_UILabel.Text = "MazeType:";
            // 
            // MazeDimension_Label
            // 
            this.MazeDimension_Label.AutoSize = true;
            this.MazeDimension_Label.Location = new System.Drawing.Point(6, 37);
            this.MazeDimension_Label.Name = "MazeDimension_Label";
            this.MazeDimension_Label.Size = new System.Drawing.Size(93, 13);
            this.MazeDimension_Label.TabIndex = 3;
            this.MazeDimension_Label.Text = "Maze Dimensions:";
            // 
            // MazeDimensions_UINumeric
            // 
            this.MazeDimensions_UINumeric.Location = new System.Drawing.Point(105, 35);
            this.MazeDimensions_UINumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MazeDimensions_UINumeric.Name = "MazeDimensions_UINumeric";
            this.MazeDimensions_UINumeric.Size = new System.Drawing.Size(109, 20);
            this.MazeDimensions_UINumeric.TabIndex = 2;
            this.MazeDimensions_UINumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // GenerateMaze_UIButton
            // 
            this.GenerateMaze_UIButton.Location = new System.Drawing.Point(105, 99);
            this.GenerateMaze_UIButton.Name = "GenerateMaze_UIButton";
            this.GenerateMaze_UIButton.Size = new System.Drawing.Size(110, 28);
            this.GenerateMaze_UIButton.TabIndex = 1;
            this.GenerateMaze_UIButton.Text = "Generate Maze";
            this.GenerateMaze_UIButton.UseVisualStyleBackColor = true;
            // 
            // SolutionOptions_UIGroupbox
            // 
            this.SolutionOptions_UIGroupbox.Controls.Add(this.chkShowAlgorithGraphics);
            this.SolutionOptions_UIGroupbox.Controls.Add(this.SetAlgorithm_Label);
            this.SolutionOptions_UIGroupbox.Controls.Add(this.SetAlgorithm_UICombobox);
            this.SolutionOptions_UIGroupbox.Location = new System.Drawing.Point(13, 163);
            this.SolutionOptions_UIGroupbox.Name = "SolutionOptions_UIGroupbox";
            this.SolutionOptions_UIGroupbox.Size = new System.Drawing.Size(222, 142);
            this.SolutionOptions_UIGroupbox.TabIndex = 1;
            this.SolutionOptions_UIGroupbox.TabStop = false;
            this.SolutionOptions_UIGroupbox.Text = "Solution Options";
            // 
            // SetAlgorithm_Label
            // 
            this.SetAlgorithm_Label.AutoSize = true;
            this.SetAlgorithm_Label.Location = new System.Drawing.Point(6, 27);
            this.SetAlgorithm_Label.Name = "SetAlgorithm_Label";
            this.SetAlgorithm_Label.Size = new System.Drawing.Size(53, 13);
            this.SetAlgorithm_Label.TabIndex = 1;
            this.SetAlgorithm_Label.Text = "Algorithm:";
            // 
            // SetAlgorithm_UICombobox
            // 
            this.SetAlgorithm_UICombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SetAlgorithm_UICombobox.FormattingEnabled = true;
            this.SetAlgorithm_UICombobox.Location = new System.Drawing.Point(105, 24);
            this.SetAlgorithm_UICombobox.Name = "SetAlgorithm_UICombobox";
            this.SetAlgorithm_UICombobox.Size = new System.Drawing.Size(109, 21);
            this.SetAlgorithm_UICombobox.TabIndex = 0;
            // 
            // ProgramOptions_UIGroupbox
            // 
            this.ProgramOptions_UIGroupbox.Controls.Add(this.CancelSolveMaze_UIButton);
            this.ProgramOptions_UIGroupbox.Controls.Add(this.SolveMaze_UIButton);
            this.ProgramOptions_UIGroupbox.Location = new System.Drawing.Point(13, 311);
            this.ProgramOptions_UIGroupbox.Name = "ProgramOptions_UIGroupbox";
            this.ProgramOptions_UIGroupbox.Size = new System.Drawing.Size(222, 116);
            this.ProgramOptions_UIGroupbox.TabIndex = 2;
            this.ProgramOptions_UIGroupbox.TabStop = false;
            this.ProgramOptions_UIGroupbox.Text = "Program Options";
            // 
            // CancelSolveMaze_UIButton
            // 
            this.CancelSolveMaze_UIButton.Location = new System.Drawing.Point(105, 69);
            this.CancelSolveMaze_UIButton.Name = "CancelSolveMaze_UIButton";
            this.CancelSolveMaze_UIButton.Size = new System.Drawing.Size(109, 28);
            this.CancelSolveMaze_UIButton.TabIndex = 2;
            this.CancelSolveMaze_UIButton.Text = "Cancel";
            this.CancelSolveMaze_UIButton.UseVisualStyleBackColor = true;
            // 
            // SolveMaze_UIButton
            // 
            this.SolveMaze_UIButton.Location = new System.Drawing.Point(105, 35);
            this.SolveMaze_UIButton.Name = "SolveMaze_UIButton";
            this.SolveMaze_UIButton.Size = new System.Drawing.Size(109, 28);
            this.SolveMaze_UIButton.TabIndex = 1;
            this.SolveMaze_UIButton.Text = "Solve";
            this.SolveMaze_UIButton.UseVisualStyleBackColor = true;
            // 
            // MazeContainer_UIGroupbox
            // 
            this.MazeContainer_UIGroupbox.AutoSize = true;
            this.MazeContainer_UIGroupbox.Controls.Add(this.Grid_UIVisualGrid);
            this.MazeContainer_UIGroupbox.Location = new System.Drawing.Point(241, 13);
            this.MazeContainer_UIGroupbox.Name = "MazeContainer_UIGroupbox";
            this.MazeContainer_UIGroupbox.Size = new System.Drawing.Size(417, 414);
            this.MazeContainer_UIGroupbox.TabIndex = 3;
            this.MazeContainer_UIGroupbox.TabStop = false;
            this.MazeContainer_UIGroupbox.Text = "Maze";
            // 
            // Grid_UIVisualGrid
            // 
            this.Grid_UIVisualGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Grid_UIVisualGrid.CellCountX = 5;
            this.Grid_UIVisualGrid.CellCountY = 5;
            this.Grid_UIVisualGrid.Location = new System.Drawing.Point(18, 20);
            this.Grid_UIVisualGrid.Name = "Grid_UIVisualGrid";
            this.Grid_UIVisualGrid.Size = new System.Drawing.Size(375, 375);
            this.Grid_UIVisualGrid.TabIndex = 0;
            this.Grid_UIVisualGrid.VisibleGridLines = false;
            // 
            // chkShowAlgorithGraphics
            // 
            this.chkShowAlgorithGraphics.AutoSize = true;
            this.chkShowAlgorithGraphics.Location = new System.Drawing.Point(10, 110);
            this.chkShowAlgorithGraphics.Name = "chkShowAlgorithGraphics";
            this.chkShowAlgorithGraphics.Size = new System.Drawing.Size(99, 17);
            this.chkShowAlgorithGraphics.TabIndex = 2;
            this.chkShowAlgorithGraphics.Text = "Show Algorithm";
            this.chkShowAlgorithGraphics.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(678, 450);
            this.Controls.Add(this.MazeContainer_UIGroupbox);
            this.Controls.Add(this.ProgramOptions_UIGroupbox);
            this.Controls.Add(this.SolutionOptions_UIGroupbox);
            this.Controls.Add(this.MazeOptions_UIGroupbox);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.MazeOptions_UIGroupbox.ResumeLayout(false);
            this.MazeOptions_UIGroupbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MazeDimensions_UINumeric)).EndInit();
            this.SolutionOptions_UIGroupbox.ResumeLayout(false);
            this.SolutionOptions_UIGroupbox.PerformLayout();
            this.ProgramOptions_UIGroupbox.ResumeLayout(false);
            this.MazeContainer_UIGroupbox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox MazeOptions_UIGroupbox;
        private System.Windows.Forms.GroupBox SolutionOptions_UIGroupbox;
        private System.Windows.Forms.GroupBox ProgramOptions_UIGroupbox;
        private System.Windows.Forms.Button SolveMaze_UIButton;
        private System.Windows.Forms.GroupBox MazeContainer_UIGroupbox;
        private System.Windows.Forms.Button GenerateMaze_UIButton;
        private System.Windows.Forms.Button CancelSolveMaze_UIButton;
        private System.Windows.Forms.ComboBox SetAlgorithm_UICombobox;
        private System.Windows.Forms.Label SetAlgorithm_Label;
        private CustomControls.VisualGrid Grid_UIVisualGrid;
        private System.Windows.Forms.NumericUpDown MazeDimensions_UINumeric;
        private System.Windows.Forms.Label MazeDimension_Label;
        private System.Windows.Forms.ComboBox SetMazeType_UIComboBox;
        private System.Windows.Forms.Label MazeType_UILabel;
        private System.Windows.Forms.CheckBox chkShowAlgorithGraphics;
    }
}