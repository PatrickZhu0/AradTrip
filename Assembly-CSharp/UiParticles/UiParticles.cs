using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UiParticles
{
	// Token: 0x02000D59 RID: 3417
	[RequireComponent(typeof(ParticleSystem))]
	public class UiParticles : MaskableGraphic
	{
		// Token: 0x1700186D RID: 6253
		// (get) Token: 0x06008AB6 RID: 35510 RVA: 0x00197D19 File Offset: 0x00196119
		// (set) Token: 0x06008AB7 RID: 35511 RVA: 0x00197D21 File Offset: 0x00196121
		public ParticleSystem ParticleSystem
		{
			get
			{
				return this.m_ParticleSystem;
			}
			set
			{
				if (SetPropertyUtility.SetClass<ParticleSystem>(ref this.m_ParticleSystem, value))
				{
					this.SetAllDirty();
				}
			}
		}

		// Token: 0x1700186E RID: 6254
		// (get) Token: 0x06008AB8 RID: 35512 RVA: 0x00197D3A File Offset: 0x0019613A
		public override Texture mainTexture
		{
			get
			{
				if (this.material != null && this.material.mainTexture != null)
				{
					return this.material.mainTexture;
				}
				return Graphic.s_WhiteTexture;
			}
		}

		// Token: 0x1700186F RID: 6255
		// (get) Token: 0x06008AB9 RID: 35513 RVA: 0x00197D74 File Offset: 0x00196174
		// (set) Token: 0x06008ABA RID: 35514 RVA: 0x00197D7C File Offset: 0x0019617C
		public UiParticleRenderMode RenderMode
		{
			get
			{
				return this.m_RenderMode;
			}
			set
			{
				if (SetPropertyUtility.SetStruct<UiParticleRenderMode>(ref this.m_RenderMode, value))
				{
					this.SetAllDirty();
				}
			}
		}

		// Token: 0x06008ABB RID: 35515 RVA: 0x00197D98 File Offset: 0x00196198
		protected override void Awake()
		{
			ParticleSystem component = base.GetComponent<ParticleSystem>();
			ParticleSystemRenderer component2 = base.GetComponent<ParticleSystemRenderer>();
			if (this.m_Material == null)
			{
				this.m_Material = component2.sharedMaterial;
			}
			if (component2.renderMode == 1)
			{
				this.RenderMode = UiParticleRenderMode.StreachedBillboard;
			}
			if (component2.renderMode == 4)
			{
				this.RenderMode = UiParticleRenderMode.Mesh;
			}
			base.Awake();
			this.ParticleSystem = component;
			this.m_ParticleSystemRenderer = component2;
			this.raycastTarget = false;
			this.initMesh = false;
		}

		// Token: 0x06008ABC RID: 35516 RVA: 0x00197E18 File Offset: 0x00196218
		protected override void Start()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			SortingGroup component = base.GetComponent<SortingGroup>();
			if (component != null)
			{
				Object.DestroyImmediate(component);
			}
			if (this.m_ParticleSystemRenderer != null && this.m_ParticleSystemRenderer.enabled)
			{
				this.m_ParticleSystemRenderer.enabled = false;
			}
		}

		// Token: 0x06008ABD RID: 35517 RVA: 0x00197E76 File Offset: 0x00196276
		public override void SetMaterialDirty()
		{
			base.SetMaterialDirty();
			if (this.m_ParticleSystemRenderer != null)
			{
				this.m_ParticleSystemRenderer.sharedMaterial = this.m_Material;
			}
		}

		// Token: 0x06008ABE RID: 35518 RVA: 0x00197EA0 File Offset: 0x001962A0
		protected override void OnPopulateMesh(VertexHelper toFill)
		{
			if (this.ParticleSystem == null)
			{
				base.OnPopulateMesh(toFill);
				return;
			}
			this.GenerateParticlesBillboards(toFill);
		}

		// Token: 0x06008ABF RID: 35519 RVA: 0x00197EC4 File Offset: 0x001962C4
		protected virtual void Update()
		{
			if (!this.m_IgnoreTimescale)
			{
				if (this.ParticleSystem != null && this.ParticleSystem.isPlaying)
				{
					this.SetVerticesDirty();
				}
			}
			else if (this.ParticleSystem != null)
			{
				this.ParticleSystem.Simulate(Time.unscaledDeltaTime, true, false);
				this.SetVerticesDirty();
			}
		}

		// Token: 0x06008AC0 RID: 35520 RVA: 0x00197F34 File Offset: 0x00196334
		private void InitParticlesBuffer()
		{
			if (this.m_Particles == null || this.m_Particles.Length < this.ParticleSystem.main.maxParticles)
			{
				this.m_Particles = new ParticleSystem.Particle[this.ParticleSystem.main.maxParticles];
			}
		}

		// Token: 0x06008AC1 RID: 35521 RVA: 0x00197F8C File Offset: 0x0019638C
		private void GenerateParticlesBillboards(VertexHelper vh)
		{
			this.InitParticlesBuffer();
			int particles = this.ParticleSystem.GetParticles(this.m_Particles);
			vh.Clear();
			if (this.m_RenderMode == UiParticleRenderMode.Billboard || this.m_RenderMode == UiParticleRenderMode.StreachedBillboard)
			{
				for (int i = 0; i < particles; i++)
				{
					this.DrawParticleBillboard(this.m_Particles[i], vh);
				}
			}
			else if (this.m_RenderMode == UiParticleRenderMode.Mesh)
			{
				for (int j = 0; j < particles; j++)
				{
					this.DrawParticleMesh(this.m_Particles[j], vh);
				}
			}
		}

		// Token: 0x06008AC2 RID: 35522 RVA: 0x00198034 File Offset: 0x00196434
		private void CheckInitMeshData()
		{
			if (!this.initMesh)
			{
				this.initMesh = true;
				this.particleMesh = this.m_ParticleSystemRenderer.mesh;
				this.vertices = this.particleMesh.vertices;
				this.colors = ((this.particleMesh.colors != null) ? this.particleMesh.colors : null);
				this.uv0s = new List<Vector2>();
				this.particleTriangles = this.particleMesh.GetTriangles(0);
				this.particleMesh.GetUVs(0, this.uv0s);
				if (this.ParticleSystem.textureSheetAnimation.enabled)
				{
					this.animateUV0s = new List<Vector2>(this.uv0s.Count);
					this.animateUV0s.AddRange(this.uv0s);
				}
			}
		}

		// Token: 0x06008AC3 RID: 35523 RVA: 0x0019810C File Offset: 0x0019650C
		private void DrawParticleMesh(ParticleSystem.Particle particle, VertexHelper vh)
		{
			this.CheckInitMeshData();
			Vector3 vector = particle.position;
			Quaternion quaternion = Quaternion.Euler(particle.rotation3D);
			if (this.ParticleSystem.main.simulationSpace == 1)
			{
				vector = base.rectTransform.InverseTransformPoint(vector);
			}
			Color32 currentColor = particle.GetCurrentColor(this.ParticleSystem);
			int currentVertCount = vh.currentVertCount;
			Vector3 currentSize3D = particle.GetCurrentSize3D(this.ParticleSystem);
			bool enabled = this.ParticleSystem.textureSheetAnimation.enabled;
			if (enabled)
			{
				float timeAlive = particle.startLifetime - particle.remainingLifetime;
				Vector2[] array = new Vector2[4];
				this.EvaluateTexturesheetUVs(particle, timeAlive, array);
				float x = array[0].x;
				float num = array[2].x - array[0].x;
				float y = array[0].y;
				float num2 = array[2].y - array[0].y;
				for (int i = 0; i < this.uv0s.Count; i++)
				{
					float num3 = x + this.uv0s[i].x * num;
					float num4 = y + this.uv0s[i].y * num2;
					this.animateUV0s[i] = new Vector2(num3, num4);
				}
			}
			if (this.colors.Length == 0)
			{
				for (int j = 0; j < this.particleMesh.vertexCount; j++)
				{
					vh.AddVert(quaternion * new Vector3(this.vertices[j].x * currentSize3D.x, this.vertices[j].y * currentSize3D.y, this.vertices[j].z * currentSize3D.z) + vector, currentColor, (!enabled) ? this.uv0s[j] : this.animateUV0s[j]);
				}
			}
			else
			{
				for (int k = 0; k < this.particleMesh.vertexCount; k++)
				{
					vh.AddVert(quaternion * new Vector3(this.vertices[k].x * currentSize3D.x, this.vertices[k].y * currentSize3D.y, this.vertices[k].z * currentSize3D.z) + vector, currentColor * this.colors[k], (!enabled) ? this.uv0s[k] : this.animateUV0s[k]);
				}
			}
			int num5 = this.particleTriangles.Length / 3;
			for (int l = 0; l < num5; l++)
			{
				vh.AddTriangle(this.particleTriangles[l * 3] + currentVertCount, this.particleTriangles[l * 3 + 1] + currentVertCount, this.particleTriangles[l * 3 + 2] + currentVertCount);
			}
		}

		// Token: 0x06008AC4 RID: 35524 RVA: 0x0019846C File Offset: 0x0019686C
		private void DrawParticleBillboard(ParticleSystem.Particle particle, VertexHelper vh)
		{
			Vector3 vector = particle.position;
			Quaternion quaternion = Quaternion.Euler(particle.rotation3D);
			if (this.ParticleSystem.main.simulationSpace == 1)
			{
				vector = base.rectTransform.InverseTransformPoint(vector);
			}
			float num = particle.startLifetime - particle.remainingLifetime;
			float timeAlive = num / particle.startLifetime;
			Vector3 currentSize3D = particle.GetCurrentSize3D(this.ParticleSystem);
			if (this.m_RenderMode == UiParticleRenderMode.StreachedBillboard)
			{
				this.GetStrechedBillboardsSizeAndRotation(particle, timeAlive, ref currentSize3D, out quaternion);
			}
			Vector3 vector2;
			vector2..ctor(-currentSize3D.x * 0.5f, currentSize3D.y * 0.5f);
			Vector3 vector3;
			vector3..ctor(currentSize3D.x * 0.5f, currentSize3D.y * 0.5f);
			Vector3 vector4;
			vector4..ctor(currentSize3D.x * 0.5f, -currentSize3D.y * 0.5f);
			Vector3 vector5;
			vector5..ctor(-currentSize3D.x * 0.5f, -currentSize3D.y * 0.5f);
			vector2 = quaternion * vector2 + vector;
			vector3 = quaternion * vector3 + vector;
			vector4 = quaternion * vector4 + vector;
			vector5 = quaternion * vector5 + vector;
			Color32 currentColor = particle.GetCurrentColor(this.ParticleSystem);
			int currentVertCount = vh.currentVertCount;
			Vector2[] array = new Vector2[4];
			if (!this.ParticleSystem.textureSheetAnimation.enabled)
			{
				this.EvaluateQuadUVs(array);
			}
			else
			{
				this.EvaluateTexturesheetUVs(particle, num, array);
			}
			vh.AddVert(vector5, currentColor, array[0]);
			vh.AddVert(vector2, currentColor, array[1]);
			vh.AddVert(vector3, currentColor, array[2]);
			vh.AddVert(vector4, currentColor, array[3]);
			vh.AddTriangle(currentVertCount, currentVertCount + 1, currentVertCount + 2);
			vh.AddTriangle(currentVertCount + 2, currentVertCount + 3, currentVertCount);
		}

		// Token: 0x06008AC5 RID: 35525 RVA: 0x0019868C File Offset: 0x00196A8C
		private void EvaluateQuadUVs(Vector2[] uvs)
		{
			uvs[0] = new Vector2(0f, 0f);
			uvs[1] = new Vector2(0f, 1f);
			uvs[2] = new Vector2(1f, 1f);
			uvs[3] = new Vector2(1f, 0f);
		}

		// Token: 0x06008AC6 RID: 35526 RVA: 0x00198708 File Offset: 0x00196B08
		private void EvaluateTexturesheetUVs(ParticleSystem.Particle particle, float timeAlive, Vector2[] uvs)
		{
			ParticleSystem.TextureSheetAnimationModule textureSheetAnimation = this.ParticleSystem.textureSheetAnimation;
			float num = particle.startLifetime / (float)textureSheetAnimation.cycleCount;
			float num2 = timeAlive % num;
			float num3 = num2 / num;
			int num4 = textureSheetAnimation.numTilesY * textureSheetAnimation.numTilesX;
			float num5 = textureSheetAnimation.frameOverTime.Evaluate(num3);
			ParticleSystemAnimationType animation = textureSheetAnimation.animation;
			float num6;
			if (animation == 1)
			{
				num6 = Mathf.Clamp(Mathf.Floor(num5 * (float)textureSheetAnimation.numTilesX), 0f, (float)(textureSheetAnimation.numTilesX - 1));
				int num7 = textureSheetAnimation.rowIndex;
				if (textureSheetAnimation.useRandomRow)
				{
					Random.InitState((int)particle.randomSeed);
					num7 = Random.Range(0, textureSheetAnimation.numTilesY);
				}
				num6 += (float)(num7 * textureSheetAnimation.numTilesX);
			}
			else
			{
				num6 = Mathf.Clamp(Mathf.Floor(num5 * (float)num4), 0f, (float)(num4 - 1));
			}
			int num8 = (int)num6 % textureSheetAnimation.numTilesX;
			int num9 = (int)num6 / textureSheetAnimation.numTilesX;
			float num10 = 1f / (float)textureSheetAnimation.numTilesX;
			float num11 = 1f / (float)textureSheetAnimation.numTilesY;
			num9 = textureSheetAnimation.numTilesY - 1 - num9;
			float num12 = (float)num8 * num10;
			float num13 = (float)num9 * num11;
			float num14 = num12 + num10;
			float num15 = num13 + num11;
			uvs[0] = new Vector2(num12, num13);
			uvs[1] = new Vector2(num12, num15);
			uvs[2] = new Vector2(num14, num15);
			uvs[3] = new Vector2(num14, num13);
		}

		// Token: 0x06008AC7 RID: 35527 RVA: 0x001988B8 File Offset: 0x00196CB8
		private void GetStrechedBillboardsSizeAndRotation(ParticleSystem.Particle particle, float timeAlive01, ref Vector3 size3D, out Quaternion rotation)
		{
			Vector3 zero = Vector3.zero;
			if (this.ParticleSystem.velocityOverLifetime.enabled)
			{
				zero.x = this.ParticleSystem.velocityOverLifetime.x.Evaluate(timeAlive01);
				zero.y = this.ParticleSystem.velocityOverLifetime.y.Evaluate(timeAlive01);
				zero.z = this.ParticleSystem.velocityOverLifetime.z.Evaluate(timeAlive01);
			}
			Vector3 vector = particle.velocity + zero;
			float num = Vector3.Angle(vector, Vector3.up);
			int num2 = (vector.x < 0f) ? 1 : -1;
			rotation = Quaternion.Euler(new Vector3(0f, 0f, num * (float)num2));
			size3D.y *= this.m_StretchedLenghScale;
			size3D += new Vector3(0f, this.m_StretchedSpeedScale * vector.magnitude);
		}

		// Token: 0x040044A4 RID: 17572
		[FormerlySerializedAs("m_ParticleSystem")]
		[SerializeField]
		private ParticleSystem m_ParticleSystem;

		// Token: 0x040044A5 RID: 17573
		[FormerlySerializedAs("m_RenderMode")]
		[SerializeField]
		[Tooltip("Render mode of particles")]
		private UiParticleRenderMode m_RenderMode;

		// Token: 0x040044A6 RID: 17574
		[FormerlySerializedAs("m_StretchedSpeedScale")]
		[SerializeField]
		[Tooltip("Speed Scale for streched billboards")]
		private float m_StretchedSpeedScale = 1f;

		// Token: 0x040044A7 RID: 17575
		[FormerlySerializedAs("m_StretchedLenghScale")]
		[SerializeField]
		[Tooltip("Speed Scale for streched billboards")]
		private float m_StretchedLenghScale = 1f;

		// Token: 0x040044A8 RID: 17576
		[FormerlySerializedAs("m_IgnoreTimescale")]
		[SerializeField]
		[Tooltip("If true, particles ignore timescale")]
		private bool m_IgnoreTimescale;

		// Token: 0x040044A9 RID: 17577
		private ParticleSystemRenderer m_ParticleSystemRenderer;

		// Token: 0x040044AA RID: 17578
		private ParticleSystem.Particle[] m_Particles;

		// Token: 0x040044AB RID: 17579
		private bool initMesh;

		// Token: 0x040044AC RID: 17580
		private Mesh particleMesh;

		// Token: 0x040044AD RID: 17581
		private Vector3[] vertices;

		// Token: 0x040044AE RID: 17582
		private Color[] colors;

		// Token: 0x040044AF RID: 17583
		private List<Vector2> uv0s;

		// Token: 0x040044B0 RID: 17584
		private List<Vector2> animateUV0s;

		// Token: 0x040044B1 RID: 17585
		private Vector3[] normals;

		// Token: 0x040044B2 RID: 17586
		private Vector4[] tangent;

		// Token: 0x040044B3 RID: 17587
		private int[] particleTriangles;
	}
}
