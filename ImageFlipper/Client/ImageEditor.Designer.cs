
namespace Client
{
    partial class ImageEditor
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
            this.FlipVerticalButton = new System.Windows.Forms.Button();
            this.FlipHorizontalButton = new System.Windows.Forms.Button();
            this.RotateCounterClockwiseButton = new System.Windows.Forms.Button();
            this.RotateClockwiseButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CloseEditorButton = new System.Windows.Forms.Button();
            this.ImageFlipperLabel = new System.Windows.Forms.Label();
            this.EditorLabel = new System.Windows.Forms.Label();
            this.SaveACopyButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FlipVerticalButton
            // 
            this.FlipVerticalButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FlipVerticalButton.BackgroundImage = global::Client.Properties.Resources.vertical_flip;
            this.FlipVerticalButton.Location = new System.Drawing.Point(233, 8);
            this.FlipVerticalButton.MaximumSize = new System.Drawing.Size(50, 50);
            this.FlipVerticalButton.Name = "FlipVerticalButton";
            this.FlipVerticalButton.Size = new System.Drawing.Size(50, 50);
            this.FlipVerticalButton.TabIndex = 4;
            this.FlipVerticalButton.UseVisualStyleBackColor = true;
            this.FlipVerticalButton.Click += new System.EventHandler(this.FlipVerticalButton_Click);
            // 
            // FlipHorizontalButton
            // 
            this.FlipHorizontalButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FlipHorizontalButton.BackgroundImage = global::Client.Properties.Resources.horizontal_flip;
            this.FlipHorizontalButton.Location = new System.Drawing.Point(160, 8);
            this.FlipHorizontalButton.Name = "FlipHorizontalButton";
            this.FlipHorizontalButton.Size = new System.Drawing.Size(50, 50);
            this.FlipHorizontalButton.TabIndex = 3;
            this.FlipHorizontalButton.UseVisualStyleBackColor = true;
            this.FlipHorizontalButton.Click += new System.EventHandler(this.FlipHorizontalButton_Click);
            // 
            // RotateCounterClockwiseButton
            // 
            this.RotateCounterClockwiseButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RotateCounterClockwiseButton.BackgroundImage = global::Client.Properties.Resources.rotate_countclockwise;
            this.RotateCounterClockwiseButton.Location = new System.Drawing.Point(88, 8);
            this.RotateCounterClockwiseButton.Name = "RotateCounterClockwiseButton";
            this.RotateCounterClockwiseButton.Size = new System.Drawing.Size(50, 50);
            this.RotateCounterClockwiseButton.TabIndex = 2;
            this.RotateCounterClockwiseButton.UseVisualStyleBackColor = true;
            this.RotateCounterClockwiseButton.Click += new System.EventHandler(this.RotateCounterClockwiseButton_Click);
            // 
            // RotateClockwiseButton
            // 
            this.RotateClockwiseButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RotateClockwiseButton.BackgroundImage = global::Client.Properties.Resources.rotate_clockwise;
            this.RotateClockwiseButton.Location = new System.Drawing.Point(16, 8);
            this.RotateClockwiseButton.Name = "RotateClockwiseButton";
            this.RotateClockwiseButton.Size = new System.Drawing.Size(50, 50);
            this.RotateClockwiseButton.TabIndex = 1;
            this.RotateClockwiseButton.UseVisualStyleBackColor = true;
            this.RotateClockwiseButton.Click += new System.EventHandler(this.RotateClockwiseButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(150, 100);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 300);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.RotateClockwiseButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.RotateCounterClockwiseButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.FlipHorizontalButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.FlipVerticalButton, 3, 0);
            this.tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(150, 450);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(300, 50);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(300, 66);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(166, 530);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(100, 30);
            this.SaveButton.TabIndex = 6;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CloseEditorButton
            // 
            this.CloseEditorButton.Location = new System.Drawing.Point(500, 10);
            this.CloseEditorButton.Name = "CloseEditorButton";
            this.CloseEditorButton.Size = new System.Drawing.Size(75, 23);
            this.CloseEditorButton.TabIndex = 7;
            this.CloseEditorButton.Text = "Close";
            this.CloseEditorButton.UseVisualStyleBackColor = true;
            this.CloseEditorButton.Click += new System.EventHandler(this.CloseEditorButton_Click);
            // 
            // ImageFlipperLabel
            // 
            this.ImageFlipperLabel.AutoSize = true;
            this.ImageFlipperLabel.Font = new System.Drawing.Font("KG Chasing Cars", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImageFlipperLabel.Location = new System.Drawing.Point(140, 10);
            this.ImageFlipperLabel.Name = "ImageFlipperLabel";
            this.ImageFlipperLabel.Size = new System.Drawing.Size(320, 47);
            this.ImageFlipperLabel.TabIndex = 8;
            this.ImageFlipperLabel.Text = "Image Flipper";
            // 
            // EditorLabel
            // 
            this.EditorLabel.AutoSize = true;
            this.EditorLabel.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditorLabel.Location = new System.Drawing.Point(260, 66);
            this.EditorLabel.Name = "EditorLabel";
            this.EditorLabel.Size = new System.Drawing.Size(79, 30);
            this.EditorLabel.TabIndex = 9;
            this.EditorLabel.Text = "Editor";
            // 
            // SaveACopyButton
            // 
            this.SaveACopyButton.Location = new System.Drawing.Point(333, 530);
            this.SaveACopyButton.Name = "SaveACopyButton";
            this.SaveACopyButton.Size = new System.Drawing.Size(100, 30);
            this.SaveACopyButton.TabIndex = 10;
            this.SaveACopyButton.Text = "Save a Copy";
            this.SaveACopyButton.UseVisualStyleBackColor = true;
            this.SaveACopyButton.Click += new System.EventHandler(this.SaveACopyButton_Click);
            // 
            // ImageEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 611);
            this.Controls.Add(this.SaveACopyButton);
            this.Controls.Add(this.EditorLabel);
            this.Controls.Add(this.ImageFlipperLabel);
            this.Controls.Add(this.CloseEditorButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ImageEditor";
            this.Text = "Image Editor";
            this.Load += new System.EventHandler(this.ImageEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button RotateClockwiseButton;
        private System.Windows.Forms.Button RotateCounterClockwiseButton;
        private System.Windows.Forms.Button FlipHorizontalButton;
        private System.Windows.Forms.Button FlipVerticalButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CloseEditorButton;
        private System.Windows.Forms.Label ImageFlipperLabel;
        private System.Windows.Forms.Label EditorLabel;
        private System.Windows.Forms.Button SaveACopyButton;
    }
}