using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02004743 RID: 18243
	[ExecuteInEditMode]
	[RequireComponent(typeof(Image))]
	internal class SpriteAniRender : MonoBehaviour
	{
		// Token: 0x0601A366 RID: 107366 RVA: 0x00824388 File Offset: 0x00822788
		public void SetEnable(bool bEnable)
		{
			if (this.image != null)
			{
				if (bEnable)
				{
					Sprite sprite = this._LoadSprite(0);
					this.image.rectTransform.sizeDelta = new Vector2(sprite.bounds.size.x * 100f * this.fScale, sprite.bounds.size.y * 100f * this.fScale);
					this.image.sprite = sprite;
				}
				else
				{
					this.image.sprite = null;
				}
				this.image.enabled = bEnable;
			}
		}

		// Token: 0x0601A367 RID: 107367 RVA: 0x0082443C File Offset: 0x0082283C
		public void Reset(string orgPath, string orgName, int count, float fScale)
		{
			this.m_AnimSpirteList.Clear();
			this.orgPath = orgPath;
			this.orgName = orgName;
			this.count = count;
			this.iIndex = 0;
			this.image = base.GetComponent<Image>();
			if (this.image.enabled)
			{
				Sprite sprite = this._LoadSprite(0);
				this.image.rectTransform.sizeDelta = new Vector2(sprite.bounds.size.x * 100f * fScale, sprite.bounds.size.y * 100f * fScale);
			}
		}

		// Token: 0x0601A368 RID: 107368 RVA: 0x008244E8 File Offset: 0x008228E8
		private void Start()
		{
			this.iIndex = 0;
			this.iInterval = 0;
			this.image = base.GetComponent<Image>();
			if (this.count < 1)
			{
				this.count = 1;
			}
			if (this.playinterval < 1)
			{
				this.playinterval = 1;
			}
			if (this.image.enabled)
			{
				Sprite sprite = this._LoadSprite(this.count - 1);
			}
		}

		// Token: 0x0601A369 RID: 107369 RVA: 0x00824554 File Offset: 0x00822954
		private void OnDestroy()
		{
			this.m_AnimSpirteList.Clear();
		}

		// Token: 0x0601A36A RID: 107370 RVA: 0x00824564 File Offset: 0x00822964
		private void Update()
		{
			if (null == this.image || !this.image.enabled)
			{
				return;
			}
			if (this.iInterval >= this.playinterval)
			{
				this.iInterval = 0;
				this._PlayOneTimes();
			}
			this.iInterval++;
		}

		// Token: 0x0601A36B RID: 107371 RVA: 0x008245C0 File Offset: 0x008229C0
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

		// Token: 0x0601A36C RID: 107372 RVA: 0x00824604 File Offset: 0x00822A04
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

		// Token: 0x0601A36D RID: 107373 RVA: 0x0082474A File Offset: 0x00822B4A
		private void _PlayOneTimes()
		{
			this.image.sprite = this._LoadSprite(this.iIndex);
			this.iIndex = (this.iIndex + 1) % this.count;
		}

		// Token: 0x04012684 RID: 75396
		public string orgPath;

		// Token: 0x04012685 RID: 75397
		public string orgName;

		// Token: 0x04012686 RID: 75398
		public int count;

		// Token: 0x04012687 RID: 75399
		public int looptimes;

		// Token: 0x04012688 RID: 75400
		public int playinterval;

		// Token: 0x04012689 RID: 75401
		private int iIndex;

		// Token: 0x0401268A RID: 75402
		private int iInterval;

		// Token: 0x0401268B RID: 75403
		private Image image;

		// Token: 0x0401268C RID: 75404
		private float fScale = 1f;

		// Token: 0x0401268D RID: 75405
		public SpeedString speedString = new SpeedString(256);

		// Token: 0x0401268E RID: 75406
		[NonSerialized]
		private List<Sprite> m_AnimSpirteList = new List<Sprite>();
	}
}
