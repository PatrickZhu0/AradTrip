using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001155 RID: 4437
	public sealed class BePoison : BeBaseFighter
	{
		// Token: 0x0600A95A RID: 43354 RVA: 0x0023C6E4 File Offset: 0x0023AAE4
		public BePoison(BePoison.BePoisonData data, ClientSystemGameBattle systemTown) : base(data, systemTown)
		{
		}

		// Token: 0x0600A95B RID: 43355 RVA: 0x0023C710 File Offset: 0x0023AB10
		public override void Update(float timeElapsed)
		{
			base.Update(timeElapsed);
			if (this._geActor == null)
			{
				return;
			}
			if (this.startShrink)
			{
				BePoison.BePoisonData bePoisonData = this._data as BePoison.BePoisonData;
				if ((float)bePoisonData.durTime > this.durShrinkTime)
				{
					float num = this.durShrinkTime / (float)bePoisonData.durTime;
					bePoisonData.MoveData.ServerPosition = Vector3.Lerp(this.startPos, bePoisonData.realPos, num);
					this.curRadius = Mathf.Lerp(this.startRadius, bePoisonData.radius, num);
					this.durShrinkTime += timeElapsed;
					this.curScale.x = this.curRadius * 0.0125f;
					this.curScale.y = 1f;
					this.curScale.z = this.curRadius * 0.0125f;
					this._geActor.SetScaleV3(this.curScale);
				}
				else
				{
					this.startShrink = false;
					this.durShrinkTime = 0f;
					bePoisonData.MoveData.ServerPosition = bePoisonData.realPos;
					this.curRadius = bePoisonData.radius;
					this.curScale.x = this.curRadius * 0.0125f;
					this.curScale.y = 1f;
					this.curScale.z = this.curRadius * 0.0125f;
					this._geActor.SetScaleV3(this.curScale);
				}
			}
		}

		// Token: 0x0600A95C RID: 43356 RVA: 0x0023C880 File Offset: 0x0023AC80
		public override void InitGeActor(GeSceneEx geScene)
		{
			this._geScene = geScene;
			if (this._geScene == null)
			{
				return;
			}
			BePoison.BePoisonData bePoisonData = this._data as BePoison.BePoisonData;
			if (bePoisonData == null)
			{
				return;
			}
			this._geActor = this._geScene.CreateActor(60441, 0, 0, false, true, true, false);
			if (this._geActor == null)
			{
				return;
			}
			if (bePoisonData.durTime == 0)
			{
				bePoisonData.MoveData.ServerPosition = bePoisonData.realPos;
				this.curScale.x = bePoisonData.radius * 0.0125f;
				this.curScale.y = 1f;
				this.curScale.z = bePoisonData.radius * 0.0125f;
				this.curRadius = bePoisonData.radius;
				this.startPos = bePoisonData.realPos;
				this.startRadius = bePoisonData.radius;
				this._geActor.SetScaleV3(this.curScale);
			}
			base.InitGeActor(geScene);
			if (bePoisonData.durTime != 0)
			{
				this.StartShrink();
			}
		}

		// Token: 0x0600A95D RID: 43357 RVA: 0x0023C982 File Offset: 0x0023AD82
		public override void Dispose()
		{
			base.Dispose();
		}

		// Token: 0x0600A95E RID: 43358 RVA: 0x0023C98C File Offset: 0x0023AD8C
		public void ResetStartInfo(float startRadius, Vector2 startPos)
		{
			this.startPos.x = startPos.x;
			this.startPos.z = startPos.y;
			this.startRadius = startRadius;
			this.curRadius = startRadius;
			BePoison.BePoisonData bePoisonData = this._data as BePoison.BePoisonData;
			bePoisonData.MoveData.ServerPosition = this.startPos;
		}

		// Token: 0x0600A95F RID: 43359 RVA: 0x0023C9E8 File Offset: 0x0023ADE8
		public void StartShrink()
		{
			BePoison.BePoisonData bePoisonData = this._data as BePoison.BePoisonData;
			if (bePoisonData == null)
			{
				return;
			}
			if ((float)bePoisonData.durTime == 0f)
			{
				return;
			}
			this.startShrink = true;
			this.durShrinkTime = bePoisonData.startTime;
			this.startPos = bePoisonData.MoveData.ServerPosition;
			this.startRadius = this.curRadius;
		}

		// Token: 0x0600A960 RID: 43360 RVA: 0x0023CA4C File Offset: 0x0023AE4C
		public void ResetCircle()
		{
			BePoison.BePoisonData bePoisonData = this._data as BePoison.BePoisonData;
			if (bePoisonData == null)
			{
				return;
			}
			bePoisonData.MoveData.ServerPosition = bePoisonData.realPos;
			this.curRadius = bePoisonData.radius;
			this.curScale.x = this.curRadius * 0.0125f;
			this.curScale.y = 1f;
			this.curScale.z = this.curRadius * 0.0125f;
			this.startShrink = false;
			this.durShrinkTime = 0f;
			if (this._geActor == null)
			{
				return;
			}
			this._geActor.SetScaleV3(this.curScale);
		}

		// Token: 0x04005E96 RID: 24214
		private const float radiusFactor = 0.0125f;

		// Token: 0x04005E97 RID: 24215
		private const string effect_chiji_duquan = "Effects/Scene_effects/Scene_Chiji/Prefab/Eff_Scene_Chiji_duquan";

		// Token: 0x04005E98 RID: 24216
		private GeEffectEx mRingEffect;

		// Token: 0x04005E99 RID: 24217
		private float curRadius;

		// Token: 0x04005E9A RID: 24218
		private bool startShrink;

		// Token: 0x04005E9B RID: 24219
		private float durShrinkTime;

		// Token: 0x04005E9C RID: 24220
		private Vector3 curScale = Vector3.one;

		// Token: 0x04005E9D RID: 24221
		private Vector3 startPos = Vector3.zero;

		// Token: 0x04005E9E RID: 24222
		private float startRadius = 1f;

		// Token: 0x02001156 RID: 4438
		public sealed class BePoisonData : BeBaseActorData
		{
			// Token: 0x04005E9F RID: 24223
			public float radius;

			// Token: 0x04005EA0 RID: 24224
			public int x;

			// Token: 0x04005EA1 RID: 24225
			public int y;

			// Token: 0x04005EA2 RID: 24226
			public Vector3 realPos;

			// Token: 0x04005EA3 RID: 24227
			public uint startTime;

			// Token: 0x04005EA4 RID: 24228
			public int durTime;
		}
	}
}
