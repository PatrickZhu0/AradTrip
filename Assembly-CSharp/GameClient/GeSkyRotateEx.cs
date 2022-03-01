using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000D92 RID: 3474
	public class GeSkyRotateEx : GeSpecialSceneEx
	{
		// Token: 0x06008CD7 RID: 36055 RVA: 0x001A21CD File Offset: 0x001A05CD
		protected override void OnInit()
		{
			base.OnInit();
			this.InitSceneSky();
		}

		// Token: 0x06008CD8 RID: 36056 RVA: 0x001A21DB File Offset: 0x001A05DB
		protected override void OnUpdate(int deltaTime)
		{
			base.OnUpdate(deltaTime);
			this.UpdateSkyRotate();
		}

		// Token: 0x06008CD9 RID: 36057 RVA: 0x001A21EA File Offset: 0x001A05EA
		protected override void OnDeInit()
		{
			base.OnDeInit();
		}

		// Token: 0x06008CDA RID: 36058 RVA: 0x001A21F4 File Offset: 0x001A05F4
		public void SetSkyRotateData(int type)
		{
			this.targetType = type;
			if (type != -1)
			{
				if (type != 0)
				{
					if (type == 1)
					{
						this.curAngleSpeed = -this.angleSpeed;
					}
				}
				else
				{
					this.curAngleSpeed = this.angleSpeed;
				}
			}
			else if (this.curAngle >= 0f)
			{
				this.curAngleSpeed = -this.angleSpeed;
			}
			else if (this.curAngle < 0f)
			{
				this.curAngleSpeed = this.angleSpeed;
			}
		}

		// Token: 0x06008CDB RID: 36059 RVA: 0x001A2288 File Offset: 0x001A0688
		private void UpdateSkyRotate()
		{
			if (this.sky == null)
			{
				return;
			}
			if (this.targetType == -1 && (double)this.curAngle >= -0.1 && (double)this.curAngle <= 0.1)
			{
				this.curAngle = 0f;
				return;
			}
			if (this.targetType == 0 && this.curAngle > this.maxRotateAngle)
			{
				return;
			}
			if (this.targetType == 1 && this.curAngle <= -this.maxRotateAngle)
			{
				return;
			}
			this.curAngle += this.curAngleSpeed;
			this.sky.localRotation = Quaternion.Euler(0f, 0f, this.curAngle);
		}

		// Token: 0x06008CDC RID: 36060 RVA: 0x001A2358 File Offset: 0x001A0758
		private void InitSceneSky()
		{
			if (this.sky != null)
			{
				return;
			}
			if (this.m_SceneObject == null)
			{
				return;
			}
			this.sky = this.m_SceneObject.transform.Find("Model/Sky/Tb_sky01");
		}

		// Token: 0x040045AA RID: 17834
		public Transform sky;

		// Token: 0x040045AB RID: 17835
		public float angleSpeed = 0.05f;

		// Token: 0x040045AC RID: 17836
		public float maxRotateAngle = 15f;

		// Token: 0x040045AD RID: 17837
		private int targetType;

		// Token: 0x040045AE RID: 17838
		private float curAngleSpeed;

		// Token: 0x040045AF RID: 17839
		private float curAngle;
	}
}
