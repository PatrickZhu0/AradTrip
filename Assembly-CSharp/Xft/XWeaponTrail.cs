using System;
using System.Collections.Generic;
using UnityEngine;

namespace Xft
{
	// Token: 0x02000DA2 RID: 3490
	public class XWeaponTrail : MonoBehaviour
	{
		// Token: 0x170018C4 RID: 6340
		// (get) Token: 0x06008D5B RID: 36187 RVA: 0x001A4A9C File Offset: 0x001A2E9C
		public float UpdateInterval
		{
			get
			{
				return 1f / this.Fps;
			}
		}

		// Token: 0x170018C5 RID: 6341
		// (get) Token: 0x06008D5C RID: 36188 RVA: 0x001A4AAA File Offset: 0x001A2EAA
		public Vector3 CurHeadPos
		{
			get
			{
				return (this.PointStart.position + this.PointEnd.position) / 2f;
			}
		}

		// Token: 0x170018C6 RID: 6342
		// (get) Token: 0x06008D5D RID: 36189 RVA: 0x001A4AD1 File Offset: 0x001A2ED1
		public float TrailWidth
		{
			get
			{
				return this.mTrailWidth;
			}
		}

		// Token: 0x06008D5E RID: 36190 RVA: 0x001A4ADC File Offset: 0x001A2EDC
		public void Init()
		{
			if (this.mInited)
			{
				return;
			}
			this.mTrailWidth = (this.PointStart.position - this.PointEnd.position).magnitude;
			this.InitMeshObj();
			this.InitOriginalElements();
			this.InitSpline();
			this.mInited = true;
		}

		// Token: 0x06008D5F RID: 36191 RVA: 0x001A4B38 File Offset: 0x001A2F38
		public void Activate()
		{
			this.Init();
			if (this.mMeshObj == null)
			{
				this.InitMeshObj();
				return;
			}
			base.gameObject.SetActive(true);
			if (this.mMeshObj != null)
			{
				this.mMeshObj.SetActive(true);
			}
			this.mFadeT = 1f;
			this.mIsFading = false;
			this.mFadeTime = 1f;
			this.mFadeElapsedime = 0f;
			this.mElapsedTime = 0f;
			for (int i = 0; i < this.mSnapshotList.Count; i++)
			{
				this.mSnapshotList[i].PointStart = this.PointStart.position;
				this.mSnapshotList[i].PointEnd = this.PointEnd.position;
				this.mSpline.ControlPoints[i].Position = this.mSnapshotList[i].Pos;
				this.mSpline.ControlPoints[i].Normal = this.mSnapshotList[i].PointEnd - this.mSnapshotList[i].PointStart;
			}
			this.RefreshSpline();
			this.UpdateVertex();
		}

		// Token: 0x06008D60 RID: 36192 RVA: 0x001A4C83 File Offset: 0x001A3083
		public void Deactivate()
		{
			base.gameObject.SetActive(false);
			if (this.mMeshObj != null)
			{
				this.mMeshObj.SetActive(false);
			}
		}

		// Token: 0x06008D61 RID: 36193 RVA: 0x001A4CAE File Offset: 0x001A30AE
		public void StopSmoothly(float fadeTime)
		{
			this.mIsFading = true;
			this.mFadeTime = fadeTime;
		}

		// Token: 0x06008D62 RID: 36194 RVA: 0x001A4CC0 File Offset: 0x001A30C0
		private void Update()
		{
			if (!this.mInited)
			{
				return;
			}
			if (this.mMeshObj == null)
			{
				this.InitMeshObj();
				return;
			}
			this.UpdateHeadElem();
			this.mElapsedTime += Time.deltaTime;
			if (this.mElapsedTime < this.UpdateInterval)
			{
				return;
			}
			this.mElapsedTime -= this.UpdateInterval;
			this.RecordCurElem();
			this.RefreshSpline();
			this.UpdateFade();
			this.UpdateVertex();
		}

		// Token: 0x06008D63 RID: 36195 RVA: 0x001A4D46 File Offset: 0x001A3146
		private void LateUpdate()
		{
			if (!this.mInited)
			{
				return;
			}
			this.mVertexPool.LateUpdate();
		}

		// Token: 0x06008D64 RID: 36196 RVA: 0x001A4D5F File Offset: 0x001A315F
		private void Start()
		{
			this.Init();
		}

		// Token: 0x06008D65 RID: 36197 RVA: 0x001A4D68 File Offset: 0x001A3168
		private void OnDrawGizmos()
		{
			if (this.PointEnd == null || this.PointStart == null)
			{
				return;
			}
			float magnitude = (this.PointStart.position - this.PointEnd.position).magnitude;
			if (magnitude < Mathf.Epsilon)
			{
				return;
			}
			Gizmos.color = Color.red;
			Gizmos.DrawSphere(this.PointStart.position, magnitude * 0.04f);
			Gizmos.color = Color.blue;
			Gizmos.DrawSphere(this.PointEnd.position, magnitude * 0.04f);
		}

		// Token: 0x06008D66 RID: 36198 RVA: 0x001A4E0C File Offset: 0x001A320C
		private void InitSpline()
		{
			this.mSpline.Granularity = this.Granularity;
			this.mSpline.Clear();
			for (int i = 0; i < this.MaxFrame; i++)
			{
				this.mSpline.AddControlPoint(this.CurHeadPos, this.PointStart.position - this.PointEnd.position);
			}
		}

		// Token: 0x06008D67 RID: 36199 RVA: 0x001A4E7C File Offset: 0x001A327C
		private void RefreshSpline()
		{
			for (int i = 0; i < this.mSnapshotList.Count; i++)
			{
				this.mSpline.ControlPoints[i].Position = this.mSnapshotList[i].Pos;
				this.mSpline.ControlPoints[i].Normal = this.mSnapshotList[i].PointEnd - this.mSnapshotList[i].PointStart;
			}
			this.mSpline.RefreshSpline();
		}

		// Token: 0x06008D68 RID: 36200 RVA: 0x001A4F14 File Offset: 0x001A3314
		private void UpdateVertex()
		{
			VertexPool pool = this.mVertexSegment.Pool;
			for (int i = 0; i < this.Granularity; i++)
			{
				int num = this.mVertexSegment.VertStart + i * 3;
				float num2 = (float)i / (float)this.Granularity;
				float tl = num2 * this.mFadeT;
				Vector2 zero = Vector2.zero;
				Vector3 vector = this.mSpline.InterpolateByLen(tl);
				Vector3 vector2 = this.mSpline.InterpolateNormalByLen(tl);
				Vector3 vector3 = vector + vector2.normalized * this.mTrailWidth * 0.5f;
				Vector3 vector4 = vector - vector2.normalized * this.mTrailWidth * 0.5f;
				pool.Vertices[num] = vector3;
				pool.Colors[num] = this.MyColor;
				zero.x = 0f;
				zero.y = num2;
				pool.UVs[num] = zero;
				pool.Vertices[num + 1] = vector;
				pool.Colors[num + 1] = this.MyColor;
				zero.x = 0.5f;
				zero.y = num2;
				pool.UVs[num + 1] = zero;
				pool.Vertices[num + 2] = vector4;
				pool.Colors[num + 2] = this.MyColor;
				zero.x = 1f;
				zero.y = num2;
				pool.UVs[num + 2] = zero;
			}
			this.mVertexSegment.Pool.UVChanged = true;
			this.mVertexSegment.Pool.VertChanged = true;
			this.mVertexSegment.Pool.ColorChanged = true;
		}

		// Token: 0x06008D69 RID: 36201 RVA: 0x001A510C File Offset: 0x001A350C
		private void UpdateIndices()
		{
			VertexPool pool = this.mVertexSegment.Pool;
			for (int i = 0; i < this.Granularity - 1; i++)
			{
				int num = this.mVertexSegment.VertStart + i * 3;
				int num2 = this.mVertexSegment.VertStart + (i + 1) * 3;
				int num3 = this.mVertexSegment.IndexStart + i * 12;
				pool.Indices[num3] = num2;
				pool.Indices[num3 + 1] = num2 + 1;
				pool.Indices[num3 + 2] = num;
				pool.Indices[num3 + 3] = num2 + 1;
				pool.Indices[num3 + 4] = num + 1;
				pool.Indices[num3 + 5] = num;
				pool.Indices[num3 + 6] = num2 + 1;
				pool.Indices[num3 + 7] = num2 + 2;
				pool.Indices[num3 + 8] = num + 1;
				pool.Indices[num3 + 9] = num2 + 2;
				pool.Indices[num3 + 10] = num + 2;
				pool.Indices[num3 + 11] = num + 1;
			}
			pool.IndiceChanged = true;
		}

		// Token: 0x06008D6A RID: 36202 RVA: 0x001A521C File Offset: 0x001A361C
		private void UpdateHeadElem()
		{
			this.mSnapshotList[0].PointStart = this.PointStart.position;
			this.mSnapshotList[0].PointEnd = this.PointEnd.position;
		}

		// Token: 0x06008D6B RID: 36203 RVA: 0x001A5258 File Offset: 0x001A3658
		private void UpdateFade()
		{
			if (!this.mIsFading)
			{
				return;
			}
			this.mFadeElapsedime += Time.deltaTime;
			float num = this.mFadeElapsedime / this.mFadeTime;
			this.mFadeT = 1f - num;
			if (this.mFadeT < 0f)
			{
				this.Deactivate();
			}
		}

		// Token: 0x06008D6C RID: 36204 RVA: 0x001A52B4 File Offset: 0x001A36B4
		private void RecordCurElem()
		{
			XWeaponTrail.Element item = new XWeaponTrail.Element(this.PointStart.position, this.PointEnd.position);
			if (this.mSnapshotList.Count < this.MaxFrame)
			{
				this.mSnapshotList.Insert(1, item);
			}
			else
			{
				this.mSnapshotList.RemoveAt(this.mSnapshotList.Count - 1);
				this.mSnapshotList.Insert(1, item);
			}
		}

		// Token: 0x06008D6D RID: 36205 RVA: 0x001A532C File Offset: 0x001A372C
		private void InitOriginalElements()
		{
			this.mSnapshotList.Clear();
			this.mSnapshotList.Add(new XWeaponTrail.Element(this.PointStart.position, this.PointEnd.position));
			this.mSnapshotList.Add(new XWeaponTrail.Element(this.PointStart.position, this.PointEnd.position));
		}

		// Token: 0x06008D6E RID: 36206 RVA: 0x001A5390 File Offset: 0x001A3790
		private void InitMeshObj()
		{
			this.mMeshObj = new GameObject("_XWeaponTrailMesh: " + base.gameObject.name);
			this.mMeshObj.layer = base.gameObject.layer;
			this.mMeshObj.SetActive(true);
			MeshFilter meshFilter = this.mMeshObj.AddComponent<MeshFilter>();
			MeshRenderer meshRenderer = this.mMeshObj.AddComponent<MeshRenderer>();
			meshRenderer.castShadows = false;
			meshRenderer.receiveShadows = false;
			meshRenderer.GetComponent<Renderer>().sharedMaterial = this.MyMaterial;
			meshFilter.sharedMesh = new Mesh();
			this.mVertexPool = new VertexPool(meshFilter.sharedMesh, this.MyMaterial);
			this.mVertexSegment = this.mVertexPool.GetVertices(this.Granularity * 3, (this.Granularity - 1) * 12);
			this.UpdateIndices();
		}

		// Token: 0x06008D6F RID: 36207 RVA: 0x001A5462 File Offset: 0x001A3862
		private void OnEnable()
		{
		}

		// Token: 0x06008D70 RID: 36208 RVA: 0x001A5464 File Offset: 0x001A3864
		private void OnDisable()
		{
			if (this.mMeshObj != null)
			{
				Object.Destroy(this.mMeshObj);
			}
		}

		// Token: 0x06008D71 RID: 36209 RVA: 0x001A5482 File Offset: 0x001A3882
		private void OnDestroy()
		{
		}

		// Token: 0x0400461A RID: 17946
		public static string Version = "1.0.1";

		// Token: 0x0400461B RID: 17947
		public Transform PointStart;

		// Token: 0x0400461C RID: 17948
		public Transform PointEnd;

		// Token: 0x0400461D RID: 17949
		public int MaxFrame = 14;

		// Token: 0x0400461E RID: 17950
		public int Granularity = 60;

		// Token: 0x0400461F RID: 17951
		public float Fps = 60f;

		// Token: 0x04004620 RID: 17952
		public Color MyColor = Color.white;

		// Token: 0x04004621 RID: 17953
		public Material MyMaterial;

		// Token: 0x04004622 RID: 17954
		protected float mTrailWidth;

		// Token: 0x04004623 RID: 17955
		protected XWeaponTrail.Element mHeadElem = new XWeaponTrail.Element();

		// Token: 0x04004624 RID: 17956
		protected List<XWeaponTrail.Element> mSnapshotList = new List<XWeaponTrail.Element>();

		// Token: 0x04004625 RID: 17957
		protected Spline mSpline = new Spline();

		// Token: 0x04004626 RID: 17958
		protected float mFadeT = 1f;

		// Token: 0x04004627 RID: 17959
		protected bool mIsFading;

		// Token: 0x04004628 RID: 17960
		protected float mFadeTime = 1f;

		// Token: 0x04004629 RID: 17961
		protected float mElapsedTime;

		// Token: 0x0400462A RID: 17962
		protected float mFadeElapsedime;

		// Token: 0x0400462B RID: 17963
		protected GameObject mMeshObj;

		// Token: 0x0400462C RID: 17964
		protected VertexPool mVertexPool;

		// Token: 0x0400462D RID: 17965
		protected VertexPool.VertexSegment mVertexSegment;

		// Token: 0x0400462E RID: 17966
		protected bool mInited;

		// Token: 0x02000DA3 RID: 3491
		public class Element
		{
			// Token: 0x06008D73 RID: 36211 RVA: 0x001A5490 File Offset: 0x001A3890
			public Element(Vector3 start, Vector3 end)
			{
				this.PointStart = start;
				this.PointEnd = end;
			}

			// Token: 0x06008D74 RID: 36212 RVA: 0x001A54A6 File Offset: 0x001A38A6
			public Element()
			{
			}

			// Token: 0x170018C7 RID: 6343
			// (get) Token: 0x06008D75 RID: 36213 RVA: 0x001A54AE File Offset: 0x001A38AE
			public Vector3 Pos
			{
				get
				{
					return (this.PointStart + this.PointEnd) / 2f;
				}
			}

			// Token: 0x0400462F RID: 17967
			public Vector3 PointStart;

			// Token: 0x04004630 RID: 17968
			public Vector3 PointEnd;
		}
	}
}
