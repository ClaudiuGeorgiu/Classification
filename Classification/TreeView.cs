using Accord.MachineLearning.DecisionTrees;
using Accord.Statistics.Filters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Classification
{
    public partial class TreeView : Form
    {
        // Value used for zooming the image.
        private double zoomFactor;
        // Value used for panning the image.
        private Point startPanningPoint;
        // Image of the tree to be shown.
        private Bitmap treeImage;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="image">Image to be shown.</param>
        public TreeView(Bitmap image)
        {
            InitializeComponent();
            this.zoomFactor = 1.0;
            this.startPanningPoint = Point.Empty;
            this.treeImage = image;
        }

        // Limit flickering.
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                // Turn on WS_EX_COMPOSITED.
                cp.ExStyle |= 0x02000000;  
                return cp;
            }
        }

        // When the image is not null, paint it on screen.
        private void tree_pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (treeImage != null)
                tree_pictureBox.Image = treeImage;
        }

        // Called when the user uses the mouse wheel (will zoom the image).
        private void TreeView_MouseWheel(object sender, MouseEventArgs e)
        {
            // Verify if there is any image to be zoomed.
            if (tree_pictureBox.Image != null)
            {
                // Zoom in.
                if (e.Delta > 0)
                {
                    // Don't zoom beyond 10 times the original size of the panel holding the image.
                    if ((tree_pictureBox.Width < (10 * tree_panel.Width)) && (tree_pictureBox.Height < (10 * tree_panel.Height)))
                    {
                        // Zoom only if mouse is within the panel.
                        if ((e.Location.X >= 0) && (e.Location.X <= tree_panel.Width) &&
                            (e.Location.Y >= 0) && (e.Location.Y <= tree_panel.Height))
                        {
                            // Increase the zoom.
                            zoomFactor *= 1.1;
                            tree_pictureBox.Width = (int)(tree_panel.Width * zoomFactor);
                            tree_pictureBox.Height = (int)(tree_panel.Height * zoomFactor);
                        }
                    }
                }
                // Zoom out.
                else
                {
                    // The minimum zoom level is the original size.
                    if ((tree_pictureBox.Width > tree_panel.Width ) && (tree_pictureBox.Height > tree_panel.Height))
                    {
                        // Zoom only if mouse is within the panel.
                        if ((e.Location.X >= 0) && (e.Location.X <= tree_panel.Width) &&
                            (e.Location.Y >= 0) && (e.Location.Y <= tree_panel.Height))
                        {
                            // Decrease the zoom.
                            zoomFactor /= 1.1;
                            tree_pictureBox.Width = (int)(tree_panel.Width * zoomFactor);
                            tree_pictureBox.Height = (int)(tree_panel.Height * zoomFactor);
                        }
                    }
                }
            }
        }

        // Called when the user clicks the mouse (in order to pan the image).
        private void tree_pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            // Register the position of the mouse when the
            // left button is clicked (pan starting point).
            if (e.Button == MouseButtons.Left)
                startPanningPoint = new Point(e.Location.X, e.Location.Y);
        }

        // Called when the user drags the mouse (in order to pan the image).
        private void tree_pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            // Pan the image using mouse's left button.
            if (e.Button == MouseButtons.Left)
            {
                // Scroll position works with inverted signs.
                tree_panel.AutoScrollPosition = new Point(
                    startPanningPoint.X - e.Location.X - tree_panel.AutoScrollPosition.X,
                    startPanningPoint.Y - e.Location.Y - tree_panel.AutoScrollPosition.Y);
            }
        }
    }
}