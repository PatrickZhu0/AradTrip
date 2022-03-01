using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02004744 RID: 18244
	[ExecuteInEditMode]
	[RequireComponent(typeof(Image))]
	internal class SpriteAniRenderChenghao : MonoBehaviour
	{
		// Token: 0x0601A36F RID: 107375 RVA: 0x00824814 File Offset: 0x00822C14
		public void SetEnable(bool bEnable)
		{
			if (this.image != null)
			{
				if (bEnable)
				{
					this.InitRes(this.image, false);
				}
				else
				{
					this.image.sprite = null;
					this.image.material = null;
					this.m_AtlasTexture = null;
				}
				this.image.enabled = bEnable;
			}
		}

		// Token: 0x0601A370 RID: 107376 RVA: 0x00824878 File Offset: 0x00822C78
		private void LoadAtlas(ref Texture2D atlasTexture, ref Sprite uniqueSprite)
		{
			atlasTexture = null;
			uniqueSprite = null;
			if (this.orgPath != string.Empty)
			{
				this.speedString.Clear();
				this.speedString.Append(this.orgPath);
				int num = this.orgPath.LastIndexOf('/');
				int num2;
				if (num > 0)
				{
					num2 = this.orgPath.LastIndexOf('/', num - 1);
				}
				else
				{
					num = this.orgPath.LastIndexOf('\\');
					num2 = this.orgPath.LastIndexOf('\\', num - 1);
				}
				string value = this.orgPath.Substring(num2 + 1, num - num2 - 1);
				this.speedString.Append(value);
				this.speedString.Append(".png");
				atlasTexture = (Singleton<AssetLoader>.instance.LoadRes(this.speedString.string_base.TrimEnd(new char[]
				{
					' '
				}), typeof(Texture2D), true, 0U).obj as Texture2D);
				this.speedString.Append(":");
				this.speedString.Append(value);
				this.speedString.Append("_0");
				uniqueSprite = (Singleton<AssetLoader>.instance.LoadRes(this.speedString.string_base.TrimEnd(new char[]
				{
					' '
				}), typeof(Sprite), true, 0U).obj as Sprite);
			}
		}

		// Token: 0x0601A371 RID: 107377 RVA: 0x008249DC File Offset: 0x00822DDC
		public void Reset(string orgPath, string orgName, int count, float fScale, string prefabPath = null)
		{
			this.m_AnimSpirteList.Clear();
			this.orgPath = orgPath;
			this.orgName = orgName;
			this.count = count;
			this.prefabPath = prefabPath;
			this.iIndex = 0;
			this.image = base.GetComponent<Image>();
			if (this.image.enabled)
			{
				this.InitRes(this.image, true);
			}
		}

		// Token: 0x0601A372 RID: 107378 RVA: 0x00824A44 File Offset: 0x00822E44
		private void InitRes(Image image, bool forceReload)
		{
			if (image && (forceReload || image.sprite == null || image.material == null))
			{
				Sprite sprite = null;
				if (string.IsNullOrEmpty(this.prefabPath))
				{
					sprite = (Singleton<AssetLoader>.instance.LoadRes("UI/Image/ChenghaoDefault/ChenghaoSprite.png:ChenghaoSprite", typeof(Sprite), true, 0U).obj as Sprite);
				}
				else
				{
					GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.prefabPath, false, 0U);
					if (gameObject != null)
					{
						GeAnimFrameBillboard component = gameObject.GetComponent<GeAnimFrameBillboard>();
						if (component != null)
						{
							this.count = component.m_FrameCount;
						}
						SpriteRenderer component2 = gameObject.GetComponent<SpriteRenderer>();
						if (component2 != null)
						{
							sprite = component2.sprite;
						}
						Object.Destroy(gameObject);
					}
				}
				Material material = Singleton<AssetLoader>.instance.LoadRes("UI/Material/ChenghaoMatImage.mat", typeof(Material), true, 0U).obj as Material;
				if (sprite && material)
				{
					image.rectTransform.sizeDelta = new Vector2(sprite.bounds.size.x * 100f * this.fScale, sprite.bounds.size.y * 100f * this.fScale);
					image.sprite = sprite;
					image.material = new Material(material);
					this.m_UVScaleOffPropertyID = Shader.PropertyToID("_AtalsTex_ST");
					Sprite sprite2 = null;
					this.LoadAtlas(ref this.m_AtlasTexture, ref sprite2);
					if (this.m_AtlasTexture)
					{
						this.m_AtlasSize.Set((float)this.m_AtlasTexture.width, (float)this.m_AtlasTexture.height);
						this.m_FrameTexSize = new Vector2(sprite.rect.width, sprite.rect.height);
						this.m_UVScaleOff.x = this.m_FrameTexSize.x / this.m_AtlasSize.x;
						this.m_UVScaleOff.y = this.m_FrameTexSize.y / this.m_AtlasSize.y;
						this.m_FrameColumn = (int)this.m_AtlasSize.x / (int)this.m_FrameTexSize.x;
						image.material.SetTexture("_AtalsTex", this.m_AtlasTexture);
						int num = 0;
						this.m_UVScaleOff.z = (float)(num % this.m_FrameColumn) * this.m_FrameTexSize.x / this.m_AtlasSize.x;
						this.m_UVScaleOff.w = 1f - (float)(num / this.m_FrameColumn + 1) * this.m_FrameTexSize.y / this.m_AtlasSize.y;
						image.material.SetVector(this.m_UVScaleOffPropertyID, this.m_UVScaleOff);
					}
				}
				image.materialForRendering.SetTexture("_AtalsTex", this.m_AtlasTexture);
				image.materialForRendering.SetVector(this.m_UVScaleOffPropertyID, this.m_UVScaleOff);
				this.m_CurTime = 0f;
			}
		}

		// Token: 0x0601A373 RID: 107379 RVA: 0x00824D78 File Offset: 0x00823178
		private void Start()
		{
			this.iIndex = 0;
			this.m_CurTime = 0f;
			this.image = base.GetComponent<Image>();
			if (this.count < 1)
			{
				this.count = 1;
			}
			if (this.image.enabled)
			{
				this.InitRes(this.image, false);
			}
		}

		// Token: 0x0601A374 RID: 107380 RVA: 0x00824DD3 File Offset: 0x008231D3
		private void OnDestroy()
		{
			this.m_AnimSpirteList.Clear();
			this.m_AtlasTexture = null;
		}

		// Token: 0x0601A375 RID: 107381 RVA: 0x00824DE8 File Offset: 0x008231E8
		private void Update()
		{
			if (null == this.image || !this.image.enabled)
			{
				return;
			}
			if (!this.image.material.name.Contains("ChenghaoMatImage"))
			{
				this.InitRes(this.image, true);
			}
			this.m_CurTime += Time.deltaTime;
			if (this.m_CurTime > this.m_FrameTime)
			{
				this.m_CurTime -= this.m_FrameTime;
				this._PlayOneTimes();
			}
		}

		// Token: 0x0601A376 RID: 107382 RVA: 0x00824E80 File Offset: 0x00823280
		private int _GetNumCount(int iValue)
		{
			iValue = ((iValue <= 0) ? (-iValue) : iValue);
			int num = 0;
			if (iValue == 0)
			{
				num = 1;
			}
			else
			{
				while (iValue > 0)
				{
					num++;
					iValue /= 10;
				}
			}
			return num;
		}

		// Token: 0x0601A377 RID: 107383 RVA: 0x00824EC4 File Offset: 0x008232C4
		private Sprite _LoadSprite(int iIndex)
		{
			if (this.m_AnimSpirteList.Count <= iIndex)
			{
				int i = this.m_AnimSpirteList.Count;
				int num = iIndex + 1;
				while (i < num)
				{
					this.speedString.Clear();
					this.speedString.Append(this.orgPath);
					this.speedString.Append(this.orgName);
					int num2 = this._GetNumCount(i);
					for (int j = 0; j < 5 - num2; j++)
					{
						this.speedString.Append(0);
					}
					this.speedString.Append(i);
					this.speedString.Append(".png:");
					this.speedString.Append(this.orgName);
					for (int k = 0; k < 5 - num2; k++)
					{
						this.speedString.Append(0);
					}
					this.speedString.Append(i);
					string path = this.speedString.string_base.TrimEnd(new char[]
					{
						' '
					});
					this.m_AnimSpirteList.Add(Singleton<AssetLoader>.instance.LoadRes(path, typeof(Sprite), true, 0U).obj as Sprite);
					i++;
				}
			}
			return this.m_AnimSpirteList[iIndex];
		}

		// Token: 0x0601A378 RID: 107384 RVA: 0x0082500C File Offset: 0x0082340C
		private void _PlayOneTimes()
		{
			if (this.m_AtlasTexture)
			{
				this.m_UVScaleOff.z = (float)(this.iIndex % this.m_FrameColumn) * this.m_FrameTexSize.x / this.m_AtlasSize.x;
				this.m_UVScaleOff.w = 1f - (float)(this.iIndex / this.m_FrameColumn + 1) * this.m_FrameTexSize.y / this.m_AtlasSize.y;
				this.image.materialForRendering.SetVector(this.m_UVScaleOffPropertyID, this.m_UVScaleOff);
				this.image.SetMaterialDirty();
			}
			this.iIndex = (this.iIndex + 1) % this.count;
		}

		// Token: 0x0401268F RID: 75407
		public string orgPath;

		// Token: 0x04012690 RID: 75408
		public string orgName;

		// Token: 0x04012691 RID: 75409
		public int count;

		// Token: 0x04012692 RID: 75410
		public string prefabPath;

		// Token: 0x04012693 RID: 75411
		private int iIndex;

		// Token: 0x04012694 RID: 75412
		private Image image;

		// Token: 0x04012695 RID: 75413
		private float fScale = 1f;

		// Token: 0x04012696 RID: 75414
		public SpeedString speedString = new SpeedString(256);

		// Token: 0x04012697 RID: 75415
		private Texture2D m_AtlasTexture;

		// Token: 0x04012698 RID: 75416
		private Vector4 m_UVScaleOff = new Vector4(1f, 1f, 0f, 0f);

		// Token: 0x04012699 RID: 75417
		private Vector2 m_AtlasSize = new Vector2(0f, 0f);

		// Token: 0x0401269A RID: 75418
		private Vector2 m_FrameTexSize = new Vector2(256f, 64f);

		// Token: 0x0401269B RID: 75419
		private int m_UVScaleOffPropertyID = -1;

		// Token: 0x0401269C RID: 75420
		private int m_FrameColumn = 1;

		// Token: 0x0401269D RID: 75421
		[NonSerialized]
		private List<Sprite> m_AnimSpirteList = new List<Sprite>();

		// Token: 0x0401269E RID: 75422
		[NonSerialized]
		protected float m_CurTime;

		// Token: 0x0401269F RID: 75423
		[NonSerialized]
		protected float m_FrameTime = 0.1f;
	}
}
