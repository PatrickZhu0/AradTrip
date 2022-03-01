using System;
using System.Collections.Generic;

namespace UnityEngine.UI
{
	// Token: 0x02000D44 RID: 3396
	public class GeUIEffectParticle : Graphic, ISerializationCallbackReceiver
	{
		// Token: 0x17001850 RID: 6224
		// (get) Token: 0x06008A20 RID: 35360 RVA: 0x001944F9 File Offset: 0x001928F9
		public GeUIParticleEmitterBase emitter
		{
			get
			{
				return this.m_ParticleEmitter;
			}
		}

		// Token: 0x06008A21 RID: 35361 RVA: 0x00194501 File Offset: 0x00192901
		public GeUIParticleEmitterBase SafeGetEmitter()
		{
			if (this.m_ParticleEmitter == null)
			{
				this._Init();
			}
			return this.m_ParticleEmitter;
		}

		// Token: 0x17001851 RID: 6225
		// (get) Token: 0x06008A22 RID: 35362 RVA: 0x0019451A File Offset: 0x0019291A
		public override Texture mainTexture
		{
			get
			{
				return (!(null == this.m_AtlasTexture.texture)) ? this.m_AtlasTexture.texture : Graphic.s_WhiteTexture;
			}
		}

		// Token: 0x06008A23 RID: 35363 RVA: 0x00194548 File Offset: 0x00192948
		public void StartEmit()
		{
			if (this.m_ParticleEmitter == null)
			{
				this._Init();
			}
			this.m_IsPlaying = true;
			this.m_IsActive = true;
			this.m_CurTimeInMS = 0;
			this.m_DelayTimeInMS = (int)(this.m_ParticleEmitter.delayEmit * 1000f);
			this.m_LastEmission = 0;
			this.m_bFirstUpdate = true;
			this.m_CurParticleNum = this.m_Particles.Count;
			Vector3 position = base.rectTransform.position;
		}

		// Token: 0x06008A24 RID: 35364 RVA: 0x001945BE File Offset: 0x001929BE
		public void StopEmit()
		{
			this.m_IsPlaying = true;
			this.m_IsActive = false;
		}

		// Token: 0x06008A25 RID: 35365 RVA: 0x001945CE File Offset: 0x001929CE
		public void RestartEmit()
		{
			this.StopEmit();
			this.StartEmit();
		}

		// Token: 0x06008A26 RID: 35366 RVA: 0x001945DC File Offset: 0x001929DC
		public void PauseEmit()
		{
			this.m_IsActive = false;
		}

		// Token: 0x06008A27 RID: 35367 RVA: 0x001945E5 File Offset: 0x001929E5
		public void ResumeEmit()
		{
			this.m_IsActive = true;
		}

		// Token: 0x06008A28 RID: 35368 RVA: 0x001945EE File Offset: 0x001929EE
		public void Freeze()
		{
			this.m_IsPlaying = false;
		}

		// Token: 0x06008A29 RID: 35369 RVA: 0x001945F7 File Offset: 0x001929F7
		public void Unfreeze()
		{
			this.m_IsPlaying = true;
		}

		// Token: 0x06008A2A RID: 35370 RVA: 0x00194600 File Offset: 0x00192A00
		public void ClearParticles()
		{
			this._ClearAllParticles();
		}

		// Token: 0x06008A2B RID: 35371 RVA: 0x00194608 File Offset: 0x00192A08
		private void _Init()
		{
			this._RebuildEmitter();
			if (this.m_TextureArray == null)
			{
				this.m_TextureArray = new Texture[]
				{
					Graphic.s_WhiteTexture
				};
			}
			if (this.m_SizeCurve != null && this.m_SizeCurve.length > 0)
			{
				this.m_SizeCurveBeginTime = this.m_SizeCurve.keys[0].time;
				this.m_SizeCurveEndTime = this.m_SizeCurve.keys[this.m_SizeCurve.length - 1].time;
			}
			if (this.m_AlphaCurve != null && this.m_AlphaCurve.length > 0)
			{
				this.m_AlphaCurveBeginTime = this.m_AlphaCurve.keys[0].time;
				this.m_AlphaCurveEndTime = this.m_AlphaCurve.keys[this.m_AlphaCurve.length - 1].time;
			}
			if (this.m_ColorRamp != null)
			{
				if (this.m_ColorRamp.colorKeys.Length > 0)
				{
					this.m_ColorRampColKeysBeginTime = this.m_ColorRamp.colorKeys[0].time;
					this.m_ColorRampColKeysEndTime = this.m_ColorRamp.colorKeys[this.m_ColorRamp.colorKeys.Length - 1].time;
				}
				if (this.m_ColorRamp.alphaKeys.Length > 0)
				{
					this.m_ColorRampAlphaKeysBeginTime = this.m_ColorRamp.alphaKeys[0].time;
					this.m_ColorRampAlphaKeysEndTime = this.m_ColorRamp.alphaKeys[this.m_ColorRamp.alphaKeys.Length - 1].time;
				}
			}
			this.m_AtlasTexture.textureArray = this.m_TextureArray;
			this.m_UIEffectGeo.Init(4);
		}

		// Token: 0x06008A2C RID: 35372 RVA: 0x001947D4 File Offset: 0x00192BD4
		protected void _Deinit()
		{
			this._ClearAllParticles();
			this.m_UIEffectGeo.Deinit();
		}

		// Token: 0x06008A2D RID: 35373 RVA: 0x001947E8 File Offset: 0x00192BE8
		protected void _Update()
		{
			if (!this.m_IsPlaying)
			{
				return;
			}
			if (this.m_bFirstUpdate)
			{
				this.m_DeltaMS = 0;
				this.m_bFirstUpdate = false;
			}
			if (this.m_DelayTimeInMS > 0)
			{
				this.m_DelayTimeInMS -= this.m_DeltaMS;
				return;
			}
			this.m_CurTimeInMS += this.m_DeltaMS;
			if (this.m_ParticleEmitter != null)
			{
				if ((long)this.m_CurTimeInMS >= (long)((ulong)this.m_ParticleEmitter.durationMS) && this.m_ParticleEmitter.durationMS > 0U)
				{
					this.m_IsActive = false;
				}
				this.m_LastEmission += this.m_DeltaMS;
				if ((float)this.m_LastEmission >= 100f / this.m_ParticleEmitter.emitRate && this.m_IsActive)
				{
					this.m_LastEmission = 0;
					this._AddParticle();
				}
			}
			this.SetVerticesDirty();
			this.SetMaterialDirty();
		}

		// Token: 0x06008A2E RID: 35374 RVA: 0x001948DC File Offset: 0x00192CDC
		protected void _RebuildEmitter()
		{
			GeUIParticleEmitterBase geUIParticleEmitterBase = null;
			switch (this.m_EmitterShape)
			{
			case EUIEffEmitShape.Point:
				geUIParticleEmitterBase = new GeUIParticleEmitterPoint();
				break;
			case EUIEffEmitShape.Circle:
				geUIParticleEmitterBase = new GeUIParticleEmitterCircle();
				break;
			case EUIEffEmitShape.Rect:
				geUIParticleEmitterBase = new GeUIParticleEmitterRect();
				break;
			case EUIEffEmitShape.Segment:
				geUIParticleEmitterBase = new GeUIParticleEmitterSegment();
				break;
			case EUIEffEmitShape.Directional:
				geUIParticleEmitterBase = new GeUIParticleEmitterDirectional();
				break;
			}
			if (geUIParticleEmitterBase != null)
			{
				GeUIEffectDataBlock[] dataBlock = GeUIEffectDataBlockSerializer.FromString(this.m_EmitDataBlockDesc);
				geUIParticleEmitterBase.LoadDataBlock(dataBlock);
			}
			this.m_ParticleEmitter = geUIParticleEmitterBase;
		}

		// Token: 0x06008A2F RID: 35375 RVA: 0x00194974 File Offset: 0x00192D74
		protected GeUIParticle _AllocParticle()
		{
			if (this.m_RecycleParticles.Count > 0)
			{
				GeUIParticle result = this.m_RecycleParticles[this.m_RecycleParticles.Count - 1];
				this.m_RecycleParticles.RemoveAt(this.m_RecycleParticles.Count - 1);
				return result;
			}
			return new GeUIParticle
			{
				m_GeometryData = this.m_UIEffectGeo.AllocGeometry(),
				Emiter = this.m_ParticleEmitter
			};
		}

		// Token: 0x06008A30 RID: 35376 RVA: 0x001949EC File Offset: 0x00192DEC
		private void _AddParticle()
		{
			int num = this.m_ParticleEmitter.partiPerEmission;
			if (this.m_ParticleEmitter.maxParticles > 0 && this.m_CurParticleNum + num > this.m_ParticleEmitter.maxParticles)
			{
				num = this.m_ParticleEmitter.maxParticles - this.m_CurParticleNum;
			}
			for (int i = 0; i < num; i++)
			{
				GeUIParticle geUIParticle = this._AllocParticle();
				float num2 = this.m_Size * this.m_SizeCurve.Evaluate(this.m_SizeCurveBeginTime);
				geUIParticle.InitSize = this.m_Size + this.m_Size * Random.Range(-this.m_SizeRangeRate, this.m_SizeRangeRate);
				geUIParticle.Size = geUIParticle.InitSize;
				geUIParticle.NTLife = 1f;
				geUIParticle.Life = this.m_LifeTime + this.m_LifeTime * Random.Range(-this.m_LifeTimeRangeRate, this.m_LifeTimeRangeRate);
				geUIParticle.SpinVel = this.m_SpinVelocity + Random.Range(-this.m_SpinVelRangeValue, this.m_SpinVelRangeValue);
				geUIParticle.Rotation = this.m_Rotate + Random.Range(-this.m_RotateRangeValue, this.m_RotateRangeValue);
				geUIParticle.Alpha = this.m_ParticleColor.a * this.m_AlphaCurve.Evaluate(this.m_AlphaCurveBeginTime);
				if (!this.m_UseLifeColor)
				{
					geUIParticle.Color = new Color(this.m_ParticleColor.r, this.m_ParticleColor.g, this.m_ParticleColor.b, geUIParticle.Alpha);
				}
				else
				{
					geUIParticle.Color = this.m_ColorRamp.Evaluate(this.m_ColorRampColKeysBeginTime);
				}
				Color color;
				color..ctor(geUIParticle.Color.r + Random.Range(-this.m_ColorRangeRate[0], this.m_ColorRangeRate[0]), geUIParticle.Color.g + Random.Range(-this.m_ColorRangeRate[1], this.m_ColorRangeRate[1]), geUIParticle.Color.b + Random.Range(-this.m_ColorRangeRate[2], this.m_ColorRangeRate[2]), geUIParticle.Alpha);
				geUIParticle.Color = color;
				float speed = this.m_Speed + this.m_Speed * Random.Range(-this.m_SpeedRangeRate, this.m_SpeedRangeRate);
				if (this.m_AtlasTexture.textureArray.Length > 0)
				{
					geUIParticle.TexFrame = 0;
				}
				if (this.m_ParticleEmitter != null)
				{
					this.m_ParticleEmitter.Emit(speed, ref geUIParticle);
				}
				geUIParticle.LastEmitPos = new Vector2(base.rectTransform.localPosition.x, base.rectTransform.localPosition.y);
				geUIParticle.TimeStampMS = this.m_CurTimeInMS;
				this.m_Particles.Add(geUIParticle);
			}
			this.m_CurParticleNum = this.m_Particles.Count;
		}

		// Token: 0x06008A31 RID: 35377 RVA: 0x00194CBD File Offset: 0x001930BD
		private void _RemoveParticle(GeUIParticle particle)
		{
			this.m_Particles.Remove(particle);
			this.m_RecycleParticles.Add(particle);
			this.m_CurParticleNum = this.m_Particles.Count;
		}

		// Token: 0x06008A32 RID: 35378 RVA: 0x00194CE9 File Offset: 0x001930E9
		private void _ClearAllParticles()
		{
			this.m_Particles.RemoveAll(delegate(GeUIParticle p)
			{
				this.m_RecycleParticles.Add(p);
				return true;
			});
			this.m_CurParticleNum = 0;
		}

		// Token: 0x06008A33 RID: 35379 RVA: 0x00194D0C File Offset: 0x0019310C
		private Canvas _GetCanvas()
		{
			GameObject gameObject = base.gameObject;
			Canvas canvas = (!(gameObject != null)) ? null : gameObject.GetComponentInParent<Canvas>();
			if (canvas != null && canvas.gameObject.activeInHierarchy)
			{
				return canvas;
			}
			canvas = (Object.FindObjectOfType(typeof(Canvas)) as Canvas);
			if (canvas != null && canvas.gameObject.activeInHierarchy)
			{
				return canvas;
			}
			return null;
		}

		// Token: 0x06008A34 RID: 35380 RVA: 0x00194D8C File Offset: 0x0019318C
		private Rect _GetRectCanvasSpace(RectTransform rectTransform)
		{
			if (this.corners == null)
			{
				this.corners = new Vector3[4];
			}
			if (this.screenCorners == null)
			{
				this.screenCorners = new Vector3[2];
			}
			Canvas canvas = this._GetCanvas();
			rectTransform.GetWorldCorners(this.corners);
			if (canvas.renderMode == 1 || canvas.renderMode == 2)
			{
				this.screenCorners[0] = RectTransformUtility.WorldToScreenPoint(canvas.worldCamera, this.corners[1]);
				this.screenCorners[1] = RectTransformUtility.WorldToScreenPoint(canvas.worldCamera, this.corners[3]);
			}
			else
			{
				this.screenCorners[0] = RectTransformUtility.WorldToScreenPoint(null, this.corners[1]);
				this.screenCorners[1] = RectTransformUtility.WorldToScreenPoint(null, this.corners[3]);
			}
			float num = this.screenCorners[0].x - canvas.GetComponent<RectTransform>().sizeDelta.x * rectTransform.pivot.x;
			float num2 = this.screenCorners[0].y - canvas.GetComponent<RectTransform>().sizeDelta.y * rectTransform.pivot.y;
			float num3 = this.screenCorners[1].x - this.screenCorners[0].x;
			float num4 = this.screenCorners[1].y - this.screenCorners[0].y;
			return new Rect(num, num2, num3, num4);
		}

		// Token: 0x06008A35 RID: 35381 RVA: 0x00194F78 File Offset: 0x00193378
		private Vector3 _RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion quat)
		{
			Vector3 vector = point - pivot;
			vector = quat * vector;
			point = vector + pivot;
			return point;
		}

		// Token: 0x06008A36 RID: 35382 RVA: 0x00194FA0 File Offset: 0x001933A0
		private Vector3 _RotatePointAroundPivotOpt(Vector3 point, Vector3 pivot, float sinAngle, float cosAngle)
		{
			float num = point.x - pivot.x;
			float num2 = point.y - pivot.y;
			float num3 = cosAngle * num - sinAngle * num2;
			float num4 = sinAngle * num + cosAngle * num2;
			point.x = num3 + pivot.x;
			point.y = num4 + pivot.y;
			return point;
		}

		// Token: 0x06008A37 RID: 35383 RVA: 0x00195000 File Offset: 0x00193400
		private void _UpdateTime(float deltaTime)
		{
			this.m_DeltaMS = (int)(deltaTime * 1000f);
		}

		// Token: 0x06008A38 RID: 35384 RVA: 0x00195010 File Offset: 0x00193410
		private Vector2 _ToCanvasPos(Vector2 pos)
		{
			Vector2 result;
			result..ctor(pos.x - base.rectTransform.localPosition.x + base.rectTransform.position.x, pos.y - base.rectTransform.localPosition.y + base.rectTransform.position.y);
			return result;
		}

		// Token: 0x06008A39 RID: 35385 RVA: 0x00195084 File Offset: 0x00193484
		private Vector2 _ToEmitPos(Vector2 pos)
		{
			Vector2 result;
			result..ctor(pos.x + base.rectTransform.localPosition.x - base.rectTransform.position.x, pos.y + base.rectTransform.localPosition.y - base.rectTransform.position.y);
			return result;
		}

		// Token: 0x06008A3A RID: 35386 RVA: 0x001950F8 File Offset: 0x001934F8
		public virtual void OnBeforeSerialize()
		{
		}

		// Token: 0x06008A3B RID: 35387 RVA: 0x001950FA File Offset: 0x001934FA
		public virtual void OnAfterDeserialize()
		{
		}

		// Token: 0x06008A3C RID: 35388 RVA: 0x001950FC File Offset: 0x001934FC
		protected override void Awake()
		{
			base.Awake();
		}

		// Token: 0x06008A3D RID: 35389 RVA: 0x00195104 File Offset: 0x00193504
		protected override void Start()
		{
			this.m_IsPlaying = false;
			this.m_IsActive = false;
			base.Start();
			if (this.m_PlayOnAwake)
			{
				this.StartEmit();
			}
		}

		// Token: 0x06008A3E RID: 35390 RVA: 0x0019512C File Offset: 0x0019352C
		protected override void OnEnable()
		{
			base.OnEnable();
			if (this.m_AtlasTexture.textureArray == null || this.m_AtlasTexture.hasDroped)
			{
				if (this.m_TextureArray == null)
				{
					this.m_TextureArray = new Texture[]
					{
						Graphic.s_WhiteTexture
					};
				}
				this.m_AtlasTexture.textureArray = this.m_TextureArray;
			}
			if (this.m_Particles == null)
			{
				this.m_Particles = new List<GeUIParticle>();
			}
		}

		// Token: 0x06008A3F RID: 35391 RVA: 0x001951A5 File Offset: 0x001935A5
		protected override void OnDisable()
		{
			base.OnDisable();
			this.m_AtlasTexture.DropTextureAtlas();
		}

		// Token: 0x06008A40 RID: 35392 RVA: 0x001951B8 File Offset: 0x001935B8
		protected override void OnDestroy()
		{
			if (this.m_ParticleEmitter != null)
			{
				this.m_ParticleEmitter.SaveDataBlock(ref this.m_EmitDataBlock);
				this.m_EmitDataBlockDesc = GeUIEffectDataBlockSerializer.ToString(this.m_EmitDataBlock);
			}
			this.m_Particles.Clear();
			this.m_RecycleParticles.Clear();
			this.m_UIEffectGeo.Clear();
		}

		// Token: 0x06008A41 RID: 35393 RVA: 0x00195213 File Offset: 0x00193613
		private void Update()
		{
			this.bHasRebuild = false;
			this._UpdateTime(Time.deltaTime);
			this._Update();
		}

		// Token: 0x06008A42 RID: 35394 RVA: 0x00195230 File Offset: 0x00193630
		private void OnDrawGizmos()
		{
			Gizmos.color = Color.white;
			Gizmos.DrawLine(base.transform.position + new Vector3(0f, -5f, 0f), base.transform.position + new Vector3(0f, 5f, 0f));
			Gizmos.DrawLine(base.transform.position + new Vector3(-5f, 0f, 0f), base.transform.position + new Vector3(5f, 0f, 0f));
		}

		// Token: 0x06008A43 RID: 35395 RVA: 0x001952E4 File Offset: 0x001936E4
		protected override void OnPopulateMesh(VertexHelper vh)
		{
			vh.Clear();
			this.verticesList.Clear();
			this.indicesList.Clear();
			int num = (int)(1000f / this.m_FrameRate);
			for (int i = 0; i < this.m_Particles.Count; i++)
			{
				GeUIParticle geUIParticle = this.m_Particles[i];
				Vector2 position = geUIParticle.Position;
				Vector2 vector = Vector2.zero;
				Vector2 vector2 = Vector2.zero;
				if (this.m_VectorParticle)
				{
					float num2 = geUIParticle.Size + this.m_Speed * this.m_VectorScalar;
					float size = geUIParticle.Size;
					vector = position + new Vector2(-num2 * 0.5f, -size * 0.5f);
					vector2 = position + new Vector2(num2 * 0.5f, size * 0.5f);
				}
				else
				{
					vector = position + new Vector2(-geUIParticle.Size * 0.5f, -geUIParticle.Size * 0.5f);
					vector2 = position + new Vector2(geUIParticle.Size * 0.5f, geUIParticle.Size * 0.5f);
				}
				geUIParticle.m_GeometryData.Pos[0] = new Vector2(vector.x, vector.y);
				geUIParticle.m_GeometryData.Pos[1] = new Vector2(vector.x, vector2.y);
				geUIParticle.m_GeometryData.Pos[2] = new Vector2(vector2.x, vector2.y);
				geUIParticle.m_GeometryData.Pos[3] = new Vector2(vector2.x, vector.y);
				float num3 = geUIParticle.Rotation * 0.017453292f;
				float sinAngle = Mathf.Sin(num3);
				float cosAngle = Mathf.Cos(num3);
				geUIParticle.m_GeometryData.Pos[0] = this._RotatePointAroundPivotOpt(geUIParticle.m_GeometryData.Pos[0], geUIParticle.Position, sinAngle, cosAngle);
				geUIParticle.m_GeometryData.Pos[1] = this._RotatePointAroundPivotOpt(geUIParticle.m_GeometryData.Pos[1], geUIParticle.Position, sinAngle, cosAngle);
				geUIParticle.m_GeometryData.Pos[2] = this._RotatePointAroundPivotOpt(geUIParticle.m_GeometryData.Pos[2], geUIParticle.Position, sinAngle, cosAngle);
				geUIParticle.m_GeometryData.Pos[3] = this._RotatePointAroundPivotOpt(geUIParticle.m_GeometryData.Pos[3], geUIParticle.Position, sinAngle, cosAngle);
				if (this.m_IsAnimatedTex)
				{
					int num4 = this.m_CurTimeInMS - geUIParticle.TimeStampMS - num;
					if (num4 > 0)
					{
						geUIParticle.TimeStampMS = this.m_CurTimeInMS + num4;
						geUIParticle.TexFrame++;
					}
					if (this.m_AnimMode == EUIAnimMode.Once)
					{
						geUIParticle.TexFrame = (int)IntMath.Clamp((long)geUIParticle.TexFrame, 0L, (long)(this.m_FrameNum - 1U));
					}
					else if (this.m_AnimMode == EUIAnimMode.Loop)
					{
						geUIParticle.TexFrame %= (int)this.m_FrameNum;
					}
				}
				if (this.m_AtlasTexture.textureArray.Length > 1)
				{
					Vector4 vector3 = this.m_AtlasTexture.atlasUVs[geUIParticle.TexFrame];
					Vector2 vector4;
					vector4..ctor(vector3.x, vector3.y);
					Vector2 vector5;
					vector5..ctor(vector3.x, vector3.w);
					Vector2 vector6;
					vector6..ctor(vector3.z, vector3.y);
					Vector2 vector7;
					vector7..ctor(vector3.z, vector3.w);
					geUIParticle.m_GeometryData.UV[0] = vector5;
					geUIParticle.m_GeometryData.UV[1] = vector4;
					geUIParticle.m_GeometryData.UV[2] = vector6;
					geUIParticle.m_GeometryData.UV[3] = vector7;
				}
				else if (this.m_IsAnimatedTex)
				{
					float num5 = 1f / this.m_FrameCellX;
					float num6 = 1f / this.m_FrameCellY;
					int num7 = geUIParticle.TexFrame % (int)this.m_FrameCellX;
					int num8 = geUIParticle.TexFrame / (int)this.m_FrameCellX;
					geUIParticle.m_GeometryData.UV[0] = new Vector2((float)num7 * num5, 1f - (float)(num8 + 1) * num6);
					geUIParticle.m_GeometryData.UV[1] = new Vector2((float)num7 * num5, 1f - (float)num8 * num6);
					geUIParticle.m_GeometryData.UV[2] = new Vector2((float)(num7 + 1) * num5, 1f - (float)num8 * num6);
					geUIParticle.m_GeometryData.UV[3] = new Vector2((float)(num7 + 1) * num5, 1f - (float)(num8 + 1) * num6);
				}
				else
				{
					Vector2 zero = Vector2.zero;
					Vector2 vector8;
					vector8..ctor(0f, 1f);
					Vector2 vector9;
					vector9..ctor(1f, 0f);
					Vector2 vector10;
					vector10..ctor(1f, 1f);
					geUIParticle.m_GeometryData.UV[0] = zero;
					geUIParticle.m_GeometryData.UV[1] = vector8;
					geUIParticle.m_GeometryData.UV[2] = vector10;
					geUIParticle.m_GeometryData.UV[3] = vector9;
				}
				for (int j = 0; j < 4; j++)
				{
					UIVertex simpleVert = UIVertex.simpleVert;
					simpleVert.color = geUIParticle.Color;
					simpleVert.position = geUIParticle.m_GeometryData.Pos[j];
					simpleVert.uv0 = geUIParticle.m_GeometryData.UV[j];
					GeUIEffectParticle.verticesCache[j] = simpleVert;
					GeUIEffectParticle.verticesIndex[j] = this.verticesList.Count + j;
				}
				this.verticesList.AddRange(GeUIEffectParticle.verticesCache);
				GeUIEffectParticle.indicesCache[0] = GeUIEffectParticle.verticesIndex[0];
				GeUIEffectParticle.indicesCache[1] = GeUIEffectParticle.verticesIndex[1];
				GeUIEffectParticle.indicesCache[2] = GeUIEffectParticle.verticesIndex[2];
				GeUIEffectParticle.indicesCache[3] = GeUIEffectParticle.verticesIndex[2];
				GeUIEffectParticle.indicesCache[4] = GeUIEffectParticle.verticesIndex[3];
				GeUIEffectParticle.indicesCache[5] = GeUIEffectParticle.verticesIndex[0];
				this.indicesList.AddRange(GeUIEffectParticle.indicesCache);
			}
			vh.AddUIVertexStream(this.verticesList, this.indicesList);
		}

		// Token: 0x06008A44 RID: 35396 RVA: 0x00195A3C File Offset: 0x00193E3C
		public override void Rebuild(CanvasUpdate update)
		{
			if (update != 3)
			{
				return;
			}
			if (this.bHasRebuild)
			{
				return;
			}
			if (this.bUnderRebuild)
			{
				return;
			}
			this.bUnderRebuild = true;
			float num = (float)this.m_CurTimeInMS * 0.001f;
			float num2 = (float)this.m_DeltaMS * 0.001f;
			for (int i = 0; i < this.m_Particles.Count; i++)
			{
				GeUIParticle geUIParticle = this.m_Particles[i];
				Vector2 vector;
				vector..ctor(Mathf.Sin(num * this.m_WaveFreq.x) * this.m_WaveAmplitude.x, Mathf.Sin(num * this.m_WaveFreq.y) * this.m_WaveAmplitude.y);
				Vector2 vector2;
				vector2..ctor(Mathf.PerlinNoise(num * this.m_TurbulenceFreq.x, 0f) * this.m_TurbulenceAmplitude.x - this.m_TurbulenceAmplitude.x * 0.5f, Mathf.PerlinNoise(num * this.m_TurbulenceFreq.y, 0f) * this.m_TurbulenceAmplitude.y - this.m_TurbulenceAmplitude.y * 0.5f);
				Vector2 gravity = this.m_Gravity;
				Vector2 vector3 = gravity + vector;
				geUIParticle.Velocity += vector3;
				Vector2 position = geUIParticle.Position;
				if (this.m_ParticleEmitter.relative)
				{
					geUIParticle.Position += geUIParticle.Velocity * num2;
				}
				else
				{
					Vector2 vector4 = geUIParticle.LastEmitPos;
					geUIParticle.LastEmitPos = new Vector2(base.rectTransform.localPosition.x, base.rectTransform.localPosition.y);
					vector4 -= geUIParticle.LastEmitPos;
					geUIParticle.Position += vector4;
					geUIParticle.Position += (geUIParticle.Velocity + vector4) * num2;
				}
				geUIParticle.Position += vector2;
				geUIParticle.NTLife = (geUIParticle.NTLife * geUIParticle.Life - num2) / geUIParticle.Life;
				geUIParticle.Rotation += geUIParticle.SpinVel * num2;
				if (this.m_AlignedSpeed)
				{
					float rotation = Mathf.Atan2(geUIParticle.Position.y - position.y, geUIParticle.Position.x - position.x) * 180f / 3.1415927f;
					geUIParticle.Rotation = rotation;
				}
				geUIParticle.Size = geUIParticle.InitSize * this.m_SizeCurve.Evaluate((1f - geUIParticle.NTLife) * this.m_SizeCurveEndTime);
				geUIParticle.Alpha = this.m_ParticleColor.a * this.m_AlphaCurve.Evaluate((1f - geUIParticle.NTLife) * this.m_AlphaCurveEndTime);
				if (!this.m_UseLifeColor)
				{
					geUIParticle.Color = new Color(geUIParticle.Color.r, geUIParticle.Color.g, geUIParticle.Color.b, geUIParticle.Alpha);
				}
				else
				{
					Color color = this.m_ColorRamp.Evaluate((1f - geUIParticle.NTLife) * this.m_ColorRampColKeysEndTime);
					geUIParticle.Color = new Color(color.r, color.g, color.b, geUIParticle.Alpha);
				}
				if (geUIParticle.NTLife <= 0f && geUIParticle.NTLife != 0f)
				{
					this._RemoveParticle(geUIParticle);
				}
			}
			if (null != this.m_EffMaterial)
			{
				this.m_EffMaterial.mainTexture = this.mainTexture;
				this.material = this.m_EffMaterial;
			}
			this.m_UpdateTick++;
			if (this.UPDATE_STEP == this.m_UpdateTick)
			{
				this.m_UpdateTick = 0;
				base.Rebuild(update);
			}
			this.bHasRebuild = true;
			this.bUnderRebuild = false;
		}

		// Token: 0x0400441C RID: 17436
		[SerializeField]
		protected bool m_PlayOnAwake = true;

		// Token: 0x0400441D RID: 17437
		[SerializeField]
		protected Material m_EffMaterial;

		// Token: 0x0400441E RID: 17438
		[SerializeField]
		protected Texture[] m_TextureArray;

		// Token: 0x0400441F RID: 17439
		[SerializeField]
		protected bool m_IsAnimatedTex;

		// Token: 0x04004420 RID: 17440
		[SerializeField]
		protected EUIAnimMode m_AnimMode = EUIAnimMode.Loop;

		// Token: 0x04004421 RID: 17441
		[SerializeField]
		protected float m_LifeTime = 2f;

		// Token: 0x04004422 RID: 17442
		[SerializeField]
		protected float m_LifeTimeRangeRate;

		// Token: 0x04004423 RID: 17443
		[SerializeField]
		protected Color m_ParticleColor = Color.white;

		// Token: 0x04004424 RID: 17444
		[SerializeField]
		protected float[] m_ColorRangeRate = new float[4];

		// Token: 0x04004425 RID: 17445
		[SerializeField]
		protected Gradient m_ColorRamp = new Gradient();

		// Token: 0x04004426 RID: 17446
		private float m_ColorRampColKeysBeginTime;

		// Token: 0x04004427 RID: 17447
		private float m_ColorRampColKeysEndTime;

		// Token: 0x04004428 RID: 17448
		private float m_ColorRampAlphaKeysBeginTime;

		// Token: 0x04004429 RID: 17449
		private float m_ColorRampAlphaKeysEndTime;

		// Token: 0x0400442A RID: 17450
		[SerializeField]
		protected AnimationCurve m_AlphaCurve = new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0f, 1f),
			new Keyframe(1f, 0f)
		});

		// Token: 0x0400442B RID: 17451
		private float m_AlphaCurveBeginTime;

		// Token: 0x0400442C RID: 17452
		private float m_AlphaCurveEndTime;

		// Token: 0x0400442D RID: 17453
		[SerializeField]
		private bool m_UseLifeColor;

		// Token: 0x0400442E RID: 17454
		[SerializeField]
		protected float m_Size = 10f;

		// Token: 0x0400442F RID: 17455
		[SerializeField]
		protected float m_SizeRangeRate;

		// Token: 0x04004430 RID: 17456
		[SerializeField]
		private AnimationCurve m_SizeCurve = new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0f, 1f),
			new Keyframe(1f, 1f)
		});

		// Token: 0x04004431 RID: 17457
		private float m_SizeCurveBeginTime;

		// Token: 0x04004432 RID: 17458
		private float m_SizeCurveEndTime;

		// Token: 0x04004433 RID: 17459
		[SerializeField]
		protected float m_Speed = 5f;

		// Token: 0x04004434 RID: 17460
		[SerializeField]
		protected float m_SpeedRangeRate;

		// Token: 0x04004435 RID: 17461
		[SerializeField]
		protected float m_SpinVelocity;

		// Token: 0x04004436 RID: 17462
		[SerializeField]
		protected float m_SpinVelRangeValue;

		// Token: 0x04004437 RID: 17463
		[SerializeField]
		protected float m_Rotate;

		// Token: 0x04004438 RID: 17464
		[SerializeField]
		protected float m_RotateRangeValue;

		// Token: 0x04004439 RID: 17465
		[SerializeField]
		protected bool m_AlignedSpeed;

		// Token: 0x0400443A RID: 17466
		[SerializeField]
		protected bool m_VectorParticle;

		// Token: 0x0400443B RID: 17467
		[SerializeField]
		protected float m_VectorScalar = 1f;

		// Token: 0x0400443C RID: 17468
		[SerializeField]
		protected Vector2 m_Gravity = Vector2.zero;

		// Token: 0x0400443D RID: 17469
		[SerializeField]
		protected Vector2 m_WaveFreq = Vector2.zero;

		// Token: 0x0400443E RID: 17470
		[SerializeField]
		protected Vector2 m_WaveAmplitude = Vector2.zero;

		// Token: 0x0400443F RID: 17471
		[SerializeField]
		protected Vector2 m_TurbulenceFreq = Vector2.zero;

		// Token: 0x04004440 RID: 17472
		[SerializeField]
		protected Vector2 m_TurbulenceAmplitude = Vector2.zero;

		// Token: 0x04004441 RID: 17473
		[SerializeField]
		protected uint m_FrameCellX = 1U;

		// Token: 0x04004442 RID: 17474
		[SerializeField]
		protected uint m_FrameCellY = 1U;

		// Token: 0x04004443 RID: 17475
		[SerializeField]
		protected uint m_FrameNum = 1U;

		// Token: 0x04004444 RID: 17476
		[SerializeField]
		protected float m_FrameRate = 30f;

		// Token: 0x04004445 RID: 17477
		[SerializeField]
		protected bool m_AlignToLife = true;

		// Token: 0x04004446 RID: 17478
		[SerializeField]
		protected EUIEffEmitShape m_EmitterShape;

		// Token: 0x04004447 RID: 17479
		[SerializeField]
		protected string[] m_EmitDataBlockDesc = new string[0];

		// Token: 0x04004448 RID: 17480
		protected GeUIEffectDataBlock[] m_EmitDataBlock;

		// Token: 0x04004449 RID: 17481
		protected GeUIEffectParticle.GeUIAtlasTexture m_AtlasTexture = new GeUIEffectParticle.GeUIAtlasTexture();

		// Token: 0x0400444A RID: 17482
		protected GeUIParticleEmitterBase m_ParticleEmitter;

		// Token: 0x0400444B RID: 17483
		protected bool bHasRebuild;

		// Token: 0x0400444C RID: 17484
		protected bool bUnderRebuild;

		// Token: 0x0400444D RID: 17485
		protected int m_UpdateTick;

		// Token: 0x0400444E RID: 17486
		protected int UPDATE_STEP = 2;

		// Token: 0x0400444F RID: 17487
		[SerializeField]
		private int m_CurParticleNum;

		// Token: 0x04004450 RID: 17488
		private List<GeUIParticle> m_Particles = new List<GeUIParticle>();

		// Token: 0x04004451 RID: 17489
		private List<GeUIParticle> m_RecycleParticles = new List<GeUIParticle>();

		// Token: 0x04004452 RID: 17490
		private GeUIEffectGeoPool m_UIEffectGeo = new GeUIEffectGeoPool();

		// Token: 0x04004453 RID: 17491
		private int m_CurTimeInMS;

		// Token: 0x04004454 RID: 17492
		private int m_DelayTimeInMS;

		// Token: 0x04004455 RID: 17493
		private int m_DeltaMS;

		// Token: 0x04004456 RID: 17494
		private int m_LastEmission;

		// Token: 0x04004457 RID: 17495
		private bool m_bFirstUpdate = true;

		// Token: 0x04004458 RID: 17496
		[SerializeField]
		private bool m_IsPlaying;

		// Token: 0x04004459 RID: 17497
		[SerializeField]
		private bool m_IsActive;

		// Token: 0x0400445A RID: 17498
		private Vector3[] corners = new Vector3[4];

		// Token: 0x0400445B RID: 17499
		private Vector3[] screenCorners = new Vector3[2];

		// Token: 0x0400445C RID: 17500
		private List<UIVertex> verticesList = new List<UIVertex>(4);

		// Token: 0x0400445D RID: 17501
		private List<int> indicesList = new List<int>(6);

		// Token: 0x0400445E RID: 17502
		private static int[] verticesIndex = new int[4];

		// Token: 0x0400445F RID: 17503
		private static UIVertex[] verticesCache = new UIVertex[4];

		// Token: 0x04004460 RID: 17504
		private static int[] indicesCache = new int[6];

		// Token: 0x02000D45 RID: 3397
		public class GeUIAtlasTexture
		{
			// Token: 0x17001852 RID: 6226
			// (get) Token: 0x06008A48 RID: 35400 RVA: 0x00195EA6 File Offset: 0x001942A6
			// (set) Token: 0x06008A49 RID: 35401 RVA: 0x00195EB0 File Offset: 0x001942B0
			public Texture[] textureArray
			{
				get
				{
					return this.m_TextureArray;
				}
				set
				{
					bool flag = true;
					if (this.m_TextureArray != null)
					{
						if (this.m_TextureArray.Length == value.Length)
						{
							for (int i = 0; i < value.Length; i++)
							{
								if (this.m_TextureArray[i] != value[i])
								{
									flag = false;
								}
							}
						}
						else
						{
							flag = false;
						}
					}
					else
					{
						flag = false;
					}
					if (flag && !this.m_HasDroped)
					{
						return;
					}
					this.m_TextureArray = null;
					this.m_AtlasTexture = null;
					this.m_AtlasUVs.Clear();
					this.m_IsGenerated = false;
					this.m_TextureArray = value;
					if (value.Length > 1)
					{
						this.CreateTextureAtlas();
					}
					else if (value.Length == 1)
					{
						this.m_AtlasTexture = value[0];
					}
					this.m_HasDroped = false;
				}
			}

			// Token: 0x17001853 RID: 6227
			// (get) Token: 0x06008A4A RID: 35402 RVA: 0x00195F79 File Offset: 0x00194379
			public Texture texture
			{
				get
				{
					return this.m_AtlasTexture;
				}
			}

			// Token: 0x17001854 RID: 6228
			// (get) Token: 0x06008A4B RID: 35403 RVA: 0x00195F81 File Offset: 0x00194381
			public bool hasDroped
			{
				get
				{
					return this.m_HasDroped;
				}
			}

			// Token: 0x17001855 RID: 6229
			// (get) Token: 0x06008A4C RID: 35404 RVA: 0x00195F89 File Offset: 0x00194389
			public List<Vector4> atlasUVs
			{
				get
				{
					return this.m_AtlasUVs;
				}
			}

			// Token: 0x06008A4D RID: 35405 RVA: 0x00195F94 File Offset: 0x00194394
			public void CreateTextureAtlas()
			{
				float num = 2f;
				List<int> list = new List<int>();
				Vector2 vector;
				vector..ctor(num, num);
				this.m_AtlasUVs.Clear();
				float num2 = 0f;
				for (int i = 0; i < this.m_TextureArray.Length; i++)
				{
					if (this.m_TextureArray != null)
					{
						if (num2 < (float)this.m_TextureArray[i].height)
						{
							num2 = (float)this.m_TextureArray[i].height + num * 2f;
						}
						vector..ctor(vector.x + (float)this.m_TextureArray[i].width + num, num2);
						list.Add(i);
					}
				}
				Texture2D texture2D = new Texture2D(Mathf.RoundToInt(vector.x), Mathf.RoundToInt(vector.y), 5, false);
				texture2D.name = "GeUIParticleAtlasTex";
				Color clear = Color.clear;
				Color[] array = new Color[texture2D.width * texture2D.height];
				for (int j = 0; j < array.Length; j++)
				{
					array[j] = clear;
				}
				texture2D.SetPixels(array);
				int num3 = Mathf.RoundToInt(num);
				for (int k = 0; k < list.Count; k++)
				{
					RenderTexture active = RenderTexture.active;
					Texture texture = this.m_TextureArray[list[k]];
					RenderTexture temporary = RenderTexture.GetTemporary(texture.width, texture.height, 0, 7, 1);
					Graphics.Blit(texture, temporary);
					RenderTexture.active = temporary;
					texture2D.ReadPixels(new Rect(0f, 0f, (float)temporary.width, (float)temporary.height), num3, Mathf.RoundToInt(num));
					texture2D.Apply();
					Vector4 item;
					item..ctor(((float)num3 - num / 2f) / (float)texture2D.width, 0f, ((float)num3 - num / 2f + (float)this.m_TextureArray[k].width) / (float)texture2D.width, 1f);
					this.m_AtlasUVs.Add(item);
					RenderTexture.ReleaseTemporary(temporary);
					RenderTexture.active = active;
					num3 += texture.width + Mathf.RoundToInt(num);
				}
				if (null != this.m_AtlasTexture && this.m_IsGenerated)
				{
					Object.Destroy(this.m_AtlasTexture);
				}
				this.m_IsGenerated = true;
				this.m_AtlasTexture = texture2D;
			}

			// Token: 0x06008A4E RID: 35406 RVA: 0x00196206 File Offset: 0x00194606
			public void DropTextureAtlas()
			{
				this.m_TextureArray = this.DEFAULT_TEX;
				this.m_AtlasTexture = Graphic.s_WhiteTexture;
				this.m_IsGenerated = false;
				this.m_AtlasUVs.Clear();
				this.m_HasDroped = true;
			}

			// Token: 0x04004461 RID: 17505
			private Texture[] m_TextureArray;

			// Token: 0x04004462 RID: 17506
			private Texture[] DEFAULT_TEX = new Texture[]
			{
				Graphic.s_WhiteTexture
			};

			// Token: 0x04004463 RID: 17507
			private Texture m_AtlasTexture;

			// Token: 0x04004464 RID: 17508
			private List<Vector4> m_AtlasUVs = new List<Vector4>();

			// Token: 0x04004465 RID: 17509
			private bool m_HasDroped;

			// Token: 0x04004466 RID: 17510
			private bool m_IsGenerated;
		}
	}
}
