using System;
using UnityEngine;

namespace Tenmove.Runtime
{
	// Token: 0x02000CF1 RID: 3313
	public class GeMaskCameraEffect : MonoBehaviour
	{
		// Token: 0x060087B7 RID: 34743 RVA: 0x0017FC48 File Offset: 0x0017E048
		private void Start()
		{
			this.m_CurrentAlpha = this.m_Sprite.color.a;
		}

		// Token: 0x060087B8 RID: 34744 RVA: 0x0017FC70 File Offset: 0x0017E070
		private void Update()
		{
			if (this.m_size != Camera.main.orthographicSize || this.m_ratio != (float)CameraAspectAdjust.GetScreenWeight() / (float)CameraAspectAdjust.GetScreenHeight())
			{
				this.ReSetRatio();
			}
			if (this.m_ChangeMode)
			{
				this.m_ChangeDuration += this.m_ChangeSpeed * Time.deltaTime;
				this.m_CurrentAlpha = Mathf.Lerp(this.m_StartAlpha, this.m_TargetAlpha, this.m_ChangeDuration);
				this.m_Sprite.material.SetFloat("_Fade", this.m_CurrentAlpha);
				if (this.m_ChangeDuration >= 1f)
				{
					this.m_ChangeDuration = 0f;
					this.m_ChangeMode = false;
				}
			}
		}

		// Token: 0x060087B9 RID: 34745 RVA: 0x0017FD30 File Offset: 0x0017E130
		public void Init(Camera cameraMain, float initialValue = 0f)
		{
			Vector3 position = cameraMain.gameObject.transform.position + cameraMain.transform.forward;
			base.gameObject.transform.position = position;
			base.gameObject.transform.SetParent(cameraMain.transform);
			this.m_Sprite.material.SetFloat("_Fade", initialValue);
			this.ReSetRatio();
		}

		// Token: 0x060087BA RID: 34746 RVA: 0x0017FDA4 File Offset: 0x0017E1A4
		private void ReSetRatio()
		{
			base.gameObject.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			this.m_size = Camera.main.orthographicSize;
			this.m_ratio = (float)CameraAspectAdjust.GetScreenWeight() / (float)CameraAspectAdjust.GetScreenHeight();
			base.gameObject.transform.localScale = new Vector3(this.m_ratio * this.m_size, this.m_size, 1f);
		}

		// Token: 0x060087BB RID: 34747 RVA: 0x0017FE28 File Offset: 0x0017E228
		public void SetGradient(float m_Target, float m_ChangeDuration)
		{
			if (m_Target == this.m_CurrentAlpha || m_ChangeDuration == 0f)
			{
				this.m_ChangeMode = false;
			}
			else
			{
				this.m_TargetAlpha = m_Target;
				this.m_ChangeSpeed = 1f / m_ChangeDuration;
				this.m_StartAlpha = this.m_CurrentAlpha;
				this.m_ChangeMode = true;
				this.ReSetRatio();
			}
		}

		// Token: 0x060087BC RID: 34748 RVA: 0x0017FE85 File Offset: 0x0017E285
		public void SetDisplay(bool ifShow)
		{
			this.ReSetRatio();
			this.m_Sprite.enabled = ifShow;
		}

		// Token: 0x060087BD RID: 34749 RVA: 0x0017FE99 File Offset: 0x0017E299
		public void SetDestory()
		{
			Object.Destroy(base.gameObject);
		}

		// Token: 0x0400416D RID: 16749
		[SerializeField]
		private SpriteRenderer m_Sprite;

		// Token: 0x0400416E RID: 16750
		private float m_StartAlpha;

		// Token: 0x0400416F RID: 16751
		private float m_CurrentAlpha;

		// Token: 0x04004170 RID: 16752
		private float m_TargetAlpha;

		// Token: 0x04004171 RID: 16753
		private float m_ChangeDuration;

		// Token: 0x04004172 RID: 16754
		private float m_ChangeSpeed;

		// Token: 0x04004173 RID: 16755
		private bool m_ChangeMode;

		// Token: 0x04004174 RID: 16756
		private float m_ratio;

		// Token: 0x04004175 RID: 16757
		private float m_size;
	}
}
