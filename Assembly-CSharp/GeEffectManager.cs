using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000CEC RID: 3308
public class GeEffectManager
{
	// Token: 0x06008791 RID: 34705 RVA: 0x0017EF00 File Offset: 0x0017D300
	public GeEffectManager()
	{
		for (int i = 0; i < 3; i++)
		{
			this.m_EffectDescList[i] = new List<GeEffectManager.GeEffectDesc>();
			this.m_IsEffectDescListDirty[i] = false;
			this.m_IsPaused[i] = false;
		}
	}

	// Token: 0x06008792 RID: 34706 RVA: 0x0017EF68 File Offset: 0x0017D368
	public void DoBackToFront()
	{
	}

	// Token: 0x06008793 RID: 34707 RVA: 0x0017EF6C File Offset: 0x0017D36C
	public void Deinit()
	{
		for (int i = 0; i < 3; i++)
		{
			List<GeEffectManager.GeEffectDesc> list = this.m_EffectDescList[i];
			list.RemoveAll(delegate(GeEffectManager.GeEffectDesc f)
			{
				Singleton<GeEffectPool>.instance.RecycleEffect(f.effect);
				f.effect = null;
				return true;
			});
			this.m_IsEffectDescListDirty[i] = false;
			this.m_IsPaused[i] = false;
		}
	}

	// Token: 0x06008794 RID: 34708 RVA: 0x0017EFCC File Offset: 0x0017D3CC
	public GeEffectEx GetEffectByName(string path)
	{
		for (int i = 0; i < 3; i++)
		{
			List<GeEffectManager.GeEffectDesc> list = this.m_EffectDescList[i];
			foreach (GeEffectManager.GeEffectDesc geEffectDesc in list)
			{
				if (geEffectDesc.effect.GetEffectName().CompareTo(path) == 0)
				{
					return geEffectDesc.effect;
				}
			}
		}
		return null;
	}

	// Token: 0x06008795 RID: 34709 RVA: 0x0017F034 File Offset: 0x0017D434
	public GeEffectEx AddEffect(DAssetObject effectRes, EffectsFrames info, float timeLength, Vector3 pos, GameObject parentNode, bool faceLeft, bool forceDisplay = false)
	{
		if (!Utility.IsStringValid(effectRes.m_AssetPath))
		{
			return null;
		}
		GeEffectType geEffectType = GeEffectType.EffectMultiple;
		if (info.timetype == EffectTimeType.GLOBAL_ANIMATION)
		{
			geEffectType = GeEffectType.EffectUnique;
		}
		else if (info.timetype == EffectTimeType.BUFF)
		{
			geEffectType = GeEffectType.EffectGlobal;
		}
		int num = (int)geEffectType;
		if (num < 3)
		{
			List<GeEffectManager.GeEffectDesc> list = this.m_EffectDescList[num];
			if (geEffectType == GeEffectType.EffectUnique)
			{
				foreach (GeEffectManager.GeEffectDesc geEffectDesc in list)
				{
					if (geEffectDesc.effect.GetEffectName().CompareTo(info.name) == 0)
					{
						return geEffectDesc.effect;
					}
				}
				timeLength = 1000f;
			}
			GeEffectEx geEffectEx = Singleton<GeEffectPool>.instance.CreateEffect(effectRes.m_AssetPath, info, timeLength, pos, faceLeft, parentNode, !forceDisplay && this.useCube);
			if (geEffectEx != null)
			{
				list.Add(new GeEffectManager.GeEffectDesc(geEffectEx));
				return geEffectEx;
			}
		}
		return null;
	}

	// Token: 0x06008796 RID: 34710 RVA: 0x0017F126 File Offset: 0x0017D526
	public GeEffectEx AddEffectInBackMode(DAssetObject effectRes, EffectsFrames info, float timeLength, Vector3 pos, GeEntity owner, string attachNode, bool faceLeft)
	{
		return null;
	}

	// Token: 0x06008797 RID: 34711 RVA: 0x0017F12C File Offset: 0x0017D52C
	public void RemoveEffect(GeEffectEx effect, GeEffectType effectType)
	{
		if (effectType < GeEffectType.EffectMaxTypeNum)
		{
			this.m_IsEffectDescListDirty[(int)effectType] = true;
			effect.Remove();
		}
	}

	// Token: 0x06008798 RID: 34712 RVA: 0x0017F158 File Offset: 0x0017D558
	public void UpdateTouchGround(float hight, int camp = 99)
	{
		if (this.lastHight == hight)
		{
			return;
		}
		this.lastHight = hight;
		for (int i = 0; i < 3; i++)
		{
			List<GeEffectManager.GeEffectDesc> list = this.m_EffectDescList[i];
			foreach (GeEffectManager.GeEffectDesc geEffectDesc in list)
			{
				if (geEffectDesc.effect.IsAlwaysTouchGround())
				{
					Vector3 position = geEffectDesc.effect.GetPosition();
					position.y = 0f;
					geEffectDesc.effect.SetPosition(position);
				}
			}
		}
	}

	// Token: 0x06008799 RID: 34713 RVA: 0x0017F1F0 File Offset: 0x0017D5F0
	public void Update(int deltaTime, GeEffectType effectType)
	{
		for (int i = 0; i < 3; i++)
		{
			if (i == (int)effectType)
			{
				if (this.m_IsEffectDescListDirty[i])
				{
					this._ClearDeadEffect(i);
				}
			}
		}
		if (!this.m_IsPaused[(int)effectType])
		{
			List<GeEffectManager.GeEffectDesc> list = this.m_EffectDescList[(int)effectType];
			foreach (GeEffectManager.GeEffectDesc geEffectDesc in list)
			{
				geEffectDesc.effect.Update(deltaTime);
				if (geEffectDesc.effect.IsDead())
				{
					this.m_IsEffectDescListDirty[1] = true;
				}
			}
		}
	}

	// Token: 0x0600879A RID: 34714 RVA: 0x0017F28C File Offset: 0x0017D68C
	protected void _ClearDeadEffect(int effectType)
	{
		if (effectType < this.m_EffectDescList.Length && effectType >= 0)
		{
			this.m_EffectDescList[effectType].RemoveAll(delegate(GeEffectManager.GeEffectDesc eff)
			{
				if (eff.effect != null && eff.effect.IsDead())
				{
					Singleton<GeEffectPool>.instance.RecycleEffect(eff.effect);
					return true;
				}
				return false;
			});
			this.m_IsEffectDescListDirty[effectType] = false;
		}
	}

	// Token: 0x0600879B RID: 34715 RVA: 0x0017F2E4 File Offset: 0x0017D6E4
	public void Pause(GeEffectType effectType)
	{
		if (effectType < GeEffectType.EffectUnique || effectType >= GeEffectType.EffectMaxTypeNum)
		{
			return;
		}
		this.m_IsPaused[(int)effectType] = true;
		for (int i = 0; i < 3; i++)
		{
			if (i == (int)effectType)
			{
				List<GeEffectManager.GeEffectDesc> list = this.m_EffectDescList[i];
				foreach (GeEffectManager.GeEffectDesc geEffectDesc in list)
				{
					geEffectDesc.effect.Pause();
				}
			}
		}
	}

	// Token: 0x0600879C RID: 34716 RVA: 0x0017F35C File Offset: 0x0017D75C
	public void SetEffectVisible(bool isVisable)
	{
		for (int i = 0; i < 3; i++)
		{
			List<GeEffectManager.GeEffectDesc> list = this.m_EffectDescList[i];
			foreach (GeEffectManager.GeEffectDesc geEffectDesc in list)
			{
				geEffectDesc.effect.SetVisible(isVisable);
			}
		}
	}

	// Token: 0x0600879D RID: 34717 RVA: 0x0017F3B4 File Offset: 0x0017D7B4
	public void Resume(GeEffectType effectType)
	{
		this.m_IsPaused[(int)effectType] = false;
		for (int i = 0; i < 3; i++)
		{
			if (i == (int)effectType)
			{
				List<GeEffectManager.GeEffectDesc> list = this.m_EffectDescList[i];
				foreach (GeEffectManager.GeEffectDesc geEffectDesc in list)
				{
					geEffectDesc.effect.Resume();
				}
			}
		}
	}

	// Token: 0x0600879E RID: 34718 RVA: 0x0017F420 File Offset: 0x0017D820
	public void ClearAll(GeEffectType effectType)
	{
		if (effectType < (GeEffectType)this.m_EffectDescList.Length)
		{
			List<GeEffectManager.GeEffectDesc> list = this.m_EffectDescList[(int)effectType];
			list.RemoveAll(delegate(GeEffectManager.GeEffectDesc f)
			{
				Singleton<GeEffectPool>.instance.RecycleEffect(f.effect);
				f.effect = null;
				return true;
			});
		}
	}

	// Token: 0x0400414C RID: 16716
	public static GeEffectManager.GeEffectDesc sInvalidEffDesc = new GeEffectManager.GeEffectDesc(null);

	// Token: 0x0400414D RID: 16717
	protected List<GeEffectManager.GeEffectDesc>[] m_EffectDescList = new List<GeEffectManager.GeEffectDesc>[3];

	// Token: 0x0400414E RID: 16718
	protected bool[] m_IsEffectDescListDirty = new bool[3];

	// Token: 0x0400414F RID: 16719
	protected bool[] m_IsPaused = new bool[3];

	// Token: 0x04004150 RID: 16720
	public bool useCube;

	// Token: 0x04004151 RID: 16721
	private float lastHight;

	// Token: 0x02000CED RID: 3309
	public struct GeEffectDesc
	{
		// Token: 0x060087A3 RID: 34723 RVA: 0x0017F4E2 File Offset: 0x0017D8E2
		public GeEffectDesc(GeEffectEx eff)
		{
			this.effect = eff;
		}

		// Token: 0x04004155 RID: 16725
		public GeEffectEx effect;
	}
}
