﻿namespace CSharpGL
{
    /// <summary>
    /// Specify a cuboid that marks a model's edges.
    /// </summary>
    public class LegacyBoundingBoxRenderer : RendererBase, IBoundingBox, IModelSpace
    {
        /// <summary>
        /// Specify a cuboid that marks a model's edges.
        /// </summary>
        public LegacyBoundingBoxRenderer()
            : this(new vec3(-0.5f, -0.5f, -0.5f), new vec3(0.5f, 0.5f, 0.5f))
        { }

        /// <summary>
        /// Specify a cuboid that marks a model's edges.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public LegacyBoundingBoxRenderer(vec3 min, vec3 max)
        {
            this.MinPosition = min;
            this.MaxPosition = max;

            this.Scale = new vec3(1, 1, 1);
            this.RotationAxis = new vec3(0, 1, 0);

            this.ModelSize = max - min;
        }

        #region IBoundingBox 成员

        /// <summary>
        /// Maximum position of this cuboid.
        /// </summary>
        public vec3 MaxPosition { get; set; }

        /// <summary>
        /// Minimum position of this cuboid.
        /// </summary>
        public vec3 MinPosition { get; set; }

        #endregion IBoundingBox 成员

        /// <summary>
        ///
        /// </summary>
        protected override void DoInitialize()
        {
        }

        /// <summary>
        /// Render something.
        /// </summary>
        /// <param name="arg"></param>
        public void Render(RenderEventArgs arg)
        {
            if (!this.IsInitialized) { Initialize(); }

            DoRender(arg);
        }

        /// <summary>
        /// Render something.
        /// </summary>
        /// <param name="arg"></param>
        protected void DoRender(RenderEventArgs arg)
        {
            this.RotationAngle += 6.0f;// 6°
            GL.Instance.LoadIdentity();
            this.LegacyTransform();

            GL.Instance.Begin((uint)DrawMode.Quads);
            GL.Instance.Color3f(1.0f, 0, 0);
            GL.Instance.Vertex3f(MinPosition.x, MinPosition.y, MinPosition.z);
            GL.Instance.Color3f(0, 1.0f, 0);
            GL.Instance.Vertex3f(MaxPosition.x, MinPosition.y, MinPosition.z);
            GL.Instance.Color3f(0, 0, 1.0f);
            GL.Instance.Vertex3f(MaxPosition.x, MinPosition.y, MaxPosition.z);
            GL.Instance.Color3f(1.0f, 1.0f, 1.0f);
            GL.Instance.Vertex3f(MinPosition.x, MinPosition.y, MaxPosition.z);
            GL.Instance.End();

            GL.Instance.Begin((uint)DrawMode.LineLoop);
            GL.Instance.Color3f(1.0f, 0, 0);
            GL.Instance.Vertex3f(MinPosition.x, MaxPosition.y, MinPosition.z);
            GL.Instance.Color3f(0, 1.0f, 0);
            GL.Instance.Vertex3f(MaxPosition.x, MaxPosition.y, MinPosition.z);
            GL.Instance.Color3f(0, 0, 1.0f);
            GL.Instance.Vertex3f(MaxPosition.x, MaxPosition.y, MaxPosition.z);
            GL.Instance.Color3f(1.0f, 1.0f, 1.0f);
            GL.Instance.Vertex3f(MinPosition.x, MaxPosition.y, MaxPosition.z);
            GL.Instance.End();

            GL.Instance.Begin((uint)DrawMode.Lines);
            GL.Instance.Color3f(1.0f, 0, 0);
            GL.Instance.Vertex3f(MinPosition.x, MinPosition.y, MinPosition.z);
            GL.Instance.Vertex3f(MinPosition.x, MaxPosition.y, MinPosition.z);
            GL.Instance.Color3f(0, 1.0f, 0);
            GL.Instance.Vertex3f(MaxPosition.x, MinPosition.y, MinPosition.z);
            GL.Instance.Vertex3f(MaxPosition.x, MaxPosition.y, MinPosition.z);
            GL.Instance.Color3f(0, 0, 1.0f);
            GL.Instance.Vertex3f(MaxPosition.x, MinPosition.y, MaxPosition.z);
            GL.Instance.Vertex3f(MaxPosition.x, MaxPosition.y, MaxPosition.z);
            GL.Instance.Color3f(1.0f, 1.0f, 1.0f);
            GL.Instance.Vertex3f(MinPosition.x, MinPosition.y, MaxPosition.z);
            GL.Instance.Vertex3f(MinPosition.x, MaxPosition.y, MaxPosition.z);
            GL.Instance.End();
        }


        #region IModelSpace 成员

        /// <summary>
        /// 
        /// </summary>
        public vec3 WorldPosition { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float RotationAngle { get; set; }

        private vec3 _rotationAxis = new vec3(0, 1, 0);
        /// <summary>
        /// 
        /// </summary>
        public vec3 RotationAxis { get { return this._rotationAxis; } set { this._rotationAxis = value; } }

        private vec3 _scale = new vec3(1, 1, 1);
        /// <summary>
        /// 
        /// </summary>
        public vec3 Scale { get { return this._scale; } set { this._scale = value; } }

        private vec3 _modelSize = new vec3(1, 1, 1);
        /// <summary>
        /// 
        /// </summary>
        public vec3 ModelSize { get { return this._modelSize; } set { this._modelSize = value; } }

        #endregion
    }
}