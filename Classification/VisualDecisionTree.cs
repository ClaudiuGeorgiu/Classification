using Accord.MachineLearning.DecisionTrees;
using Accord.Statistics.Filters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Classification
{
    /// <summary>
    /// Class creating a visual decision tree
    /// for a given binary tree.
    /// </summary>
    public class VisualDecisionTree
    {
        // Tree to be drawn.
        private DecisionTree decisionTree;
        // Give each node a position (for drawing).
        private Dictionary<DecisionNode, Point> nodePositions;
        // Drawing tool.
        private Graphics graphics;
        // Drawn image of the decision tree.
        private Bitmap treeImage;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="tree">Decision tree to be drawn.</param>
        public VisualDecisionTree(DecisionTree tree)
        {
            this.decisionTree = tree;
        }

        /// <summary>
        /// Recursive function to give a position to each node in
        /// the tree, in order to create a visual horizontal tree.
        /// </summary>
        /// <param name="rootNode">The root node of the tree.</param>
        /// <param name="rootNodePosition">The root node's position.</param>
        /// <param name="verticalDistance">The vertical space between
        /// the first two nodes (for the other nodes it changes
        /// automatically).</param>
        /// <param name="horizontalDistance">The horizontal space
        /// between nodes (remains the same for all nodes).</param>
        private void createHorizontalTreeStructure(
            DecisionNode rootNode,
            Point rootNodePosition,
            int verticalDistance,
            int horizontalDistance)
        {
            if (rootNode == null)
                return;

            // Assign the position to the node.
            nodePositions.Add(rootNode, rootNodePosition);

            // Working with a horizontal binary tree, for each
            // new level of the tree the vertical distance
            // between nodes gets halved.
            verticalDistance /= 2;

            // Work with binary trees.
            if (rootNode.Branches.Count == 2)
            {
                // Left node goes down in the horizontal structure.
                createHorizontalTreeStructure(
                    rootNode.Branches[0],
                    new Point(rootNodePosition.X + horizontalDistance, rootNodePosition.Y + verticalDistance),
                    verticalDistance,
                    horizontalDistance);

                // Right node goes up in the horizontal structure.
                createHorizontalTreeStructure(
                    rootNode.Branches[1],
                    new Point(rootNodePosition.X + horizontalDistance, rootNodePosition.Y - verticalDistance),
                    verticalDistance,
                    horizontalDistance);
            }
        }

        /// <summary>
        /// Draw tree's nodes and links between nodes with a
        /// horizontal layout.
        /// </summary>
        /// <param name="attributeToPredict">Predicted attribute in
        /// leaf nodes.</param>
        /// <param name="codeBook">Codebook to convert to string
        /// predicted attribute.</param>
        /// <param name="minHorizontalDistance">Minimum horizontal
        /// distance between nodes (in pixels).</param>
        /// <param name="minVerticalDistance">Minimum vertical
        /// distance between nodes (in pixels).</param>
        /// <param name="startingNode">The starting node of the drawing
        /// (if no node is given, drawing will start from root).</param>
        /// <returns>Image containing the decision tree.</returns>
        public Bitmap drawHorizontalTree(
            string attributeToPredict,
            Codification codeBook,
            int minHorizontalDistance = 400,
            int minVerticalDistance = 80,
            DecisionNode startingNode = null)
        {
            if (startingNode == null)
                startingNode = decisionTree.Root;

            int treeHeight = decisionTree.GetHeight();

            // Define the drawing size (must contain the entire tree).
            int treeDrawingWidth = minHorizontalDistance * treeHeight + 300;
            int treeDrawingHeight = minVerticalDistance << treeHeight;

            // Make some initialization.
            treeImage = new Bitmap(treeDrawingWidth, treeDrawingHeight);
            graphics = Graphics.FromImage(treeImage);
            graphics.Clear(Color.White);
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            nodePositions = new Dictionary<DecisionNode, Point>();
            Pen redPen = new Pen(Color.Red, 4);
            Pen greenPen = new Pen(Color.Green, 4);

            // Create the tree structure, making sure it
            // will be smaller than the drawing size.
            createHorizontalTreeStructure(startingNode,
                new Point(50, treeDrawingHeight / 2),
                treeDrawingHeight / 2,
                minHorizontalDistance);

            // Draw links between nodes.
            foreach (DecisionNode node in nodePositions.Keys)
            {
                if ((node.Parent != null) && (nodePositions.ContainsKey(node.Parent)))
                {
                    graphics.DrawLine(
                        redPen,
                        nodePositions[node.Parent],
                        nodePositions[node]);
                    graphics.FillEllipse(
                        new SolidBrush(Color.White),
                        nodePositions[node.Parent].X - 15,
                        nodePositions[node.Parent].Y - 15,
                        30,
                        30);
                    graphics.DrawEllipse(
                        redPen,
                        nodePositions[node.Parent].X - 15,
                        nodePositions[node.Parent].Y - 15,
                        30,
                        30);
                }
            }

            // Draw node labels.
            foreach (DecisionNode node in nodePositions.Keys)
            {
                if ((node.Parent != null) && (nodePositions.ContainsKey(node.Parent)))
                {
                    // Some labels will be drawn slightly below
                    // the links, following their inclination.
                    Point temp = new Point();
                    temp.X = nodePositions[node.Parent].X;
                    temp.Y = nodePositions[node.Parent].Y + 5;
                    float angle = (float)Math.Atan2(
                        (double)(nodePositions[node].Y - nodePositions[node.Parent].Y),
                        (double)(nodePositions[node].X - nodePositions[node.Parent].X));

                    // Convert from radiants to degrees.
                    angle = angle * 360 / (2 * (float)Math.PI);

                    // Draw leaf nodes' labels.
                    if (node.IsLeaf)
                    {
                        // Draw leaf node's label surrounded by a rectangle.
                        graphics.DrawString(
                            codeBook.Translate(attributeToPredict, (int)node.Output),
                            new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.Green),
                            new RectangleF(new Point(nodePositions[node].X, nodePositions[node].Y - 20), new Size(200, 40)),
                            new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                        graphics.DrawRectangle(
                            greenPen,
                            new Rectangle(new Point(nodePositions[node].X, nodePositions[node].Y - 20),
                            new Size(200, 40)));

                        // Draw leaf node's link label along the link.
                        using (Matrix rotationMatrix = new Matrix())
                        {
                            rotationMatrix.RotateAt(angle, temp);
                            graphics.Transform = rotationMatrix;
                            graphics.DrawString(node.ToString(),
                                new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.Green),
                                new RectangleF(temp,
                                // Get the length of the link using Pythagorean theorem.
                                    new Size((int)Math.Sqrt(
                                        Math.Pow(nodePositions[node].X - nodePositions[node.Parent].X, 2) +
                                        Math.Pow(nodePositions[node].Y - nodePositions[node.Parent].Y, 2)),
                                    40)),
                                new StringFormat() { Alignment = StringAlignment.Center });
                            graphics.ResetTransform();
                        }
                    }
                    // Draw labels of the remaining links between nodes.
                    else
                        using (Matrix rotationMatrix = new Matrix())
                        {
                            rotationMatrix.RotateAt(angle, temp);
                            graphics.Transform = rotationMatrix;
                            graphics.DrawString(node.ToString(),
                                new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.Green),
                                new RectangleF(temp,
                                // Get the length of the link using Pythagorean theorem.
                                    new Size((int)Math.Sqrt(
                                        Math.Pow(nodePositions[node].X - nodePositions[node.Parent].X, 2) +
                                        Math.Pow(nodePositions[node].Y - nodePositions[node.Parent].Y, 2)),
                                    40)),
                                new StringFormat() { Alignment = StringAlignment.Center });
                            graphics.ResetTransform();
                        }
                }
                // Draw root node's label.
                else if (nodePositions.ContainsKey(node))
                    graphics.DrawString(node.ToString(),
                            new Font("Arial", 15, FontStyle.Bold),
                            new SolidBrush(Color.Green),
                            new RectangleF(new Point(nodePositions[node].X + 30, nodePositions[node].Y - 30), new Size(300, 60)),
                            new StringFormat() { LineAlignment = StringAlignment.Center });
            }
            // Return the drawn tree.
            return treeImage;
        }
    }
}