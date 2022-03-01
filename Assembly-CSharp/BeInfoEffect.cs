using System;
using ProtoTable;
using UnityEngine;

// Token: 0x02004197 RID: 16791
public class BeInfoEffect
{
	// Token: 0x06017088 RID: 94344 RVA: 0x00710CC8 File Offset: 0x0070F0C8
	public void ChangeEffectFrames(ref EffectsFrames effectInfo, int hitEffectInfoTableId)
	{
		if (effectInfo == null)
		{
			effectInfo = new EffectsFrames();
		}
		effectInfo.localPosition = Vector3.zero;
		effectInfo.localScale = Vector3.one;
		if (this.hitEffectInfoId != hitEffectInfoTableId)
		{
			this.hitEffectInfoId = hitEffectInfoTableId;
			this.hitEffectInfoItem = Singleton<TableManager>.GetInstance().GetTableItem<HitEffectInfoTable>(this.hitEffectInfoId, string.Empty, string.Empty);
			this.actionCreateEffectNum = 0;
		}
		if (this.hitEffectInfoItem != null && this.hitEffectInfoItem.OffsetX.Count > 0)
		{
			int index = 0;
			if (this.hitEffectInfoItem.Type == 0)
			{
				if (this.hitEffectInfoItem.Loop == 1)
				{
					index = this.actionCreateEffectNum % this.hitEffectInfoItem.OffsetX.Count;
				}
				else
				{
					index = Math.Min(this.actionCreateEffectNum, this.hitEffectInfoItem.OffsetX.Count);
				}
			}
			else if (this.hitEffectInfoItem.Type == 1)
			{
				if (this.hitEffectIndexRand == null)
				{
					this.hitEffectIndexRand = new Random();
				}
				index = this.hitEffectIndexRand.Next(this.hitEffectInfoItem.OffsetX.Count);
			}
			effectInfo.localPosition = new Vector3((float)this.hitEffectInfoItem.OffsetX[index] / 100f, (float)this.hitEffectInfoItem.OffsetY[index] / 100f, 0f);
			effectInfo.localRotation = Quaternion.Euler((float)this.hitEffectInfoItem.RotateX[index] / 100f, (float)this.hitEffectInfoItem.RotateY[index] / 100f, (float)this.hitEffectInfoItem.RotateZ[index] / 100f);
			effectInfo.localScale *= (float)this.hitEffectInfoItem.Scale[index] / 100f;
			if (effectInfo.localScale.x == 0f)
			{
				Vector3 localScale = effectInfo.localScale;
				localScale.x = 0.0001f;
				effectInfo.localScale = localScale;
			}
			this.actionCreateEffectNum++;
		}
	}

	// Token: 0x0401095E RID: 67934
	protected int hitEffectInfoId;

	// Token: 0x0401095F RID: 67935
	protected HitEffectInfoTable hitEffectInfoItem;

	// Token: 0x04010960 RID: 67936
	protected Random hitEffectIndexRand;

	// Token: 0x04010961 RID: 67937
	protected int actionCreateEffectNum;
}
