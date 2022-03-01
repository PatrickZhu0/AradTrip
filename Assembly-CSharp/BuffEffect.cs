using System;
using GameClient;
using ProtoTable;
using UnityEngine;

// Token: 0x020041CE RID: 16846
public class BuffEffect
{
	// Token: 0x060173E7 RID: 95207 RVA: 0x007256C4 File Offset: 0x00723AC4
	public void Init(int buffid, bool buffEffectAni = true)
	{
		this.buffEffectAni = buffEffectAni;
		BuffTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BuffTable>(buffid, string.Empty, string.Empty);
		if (tableItem != null)
		{
			if (Utility.IsStringValid(tableItem.EffectShaderName))
			{
				BuffEffect.BuffEffectConfig config = default(BuffEffect.BuffEffectConfig);
				config.InitWithShader(tableItem.EffectShaderName);
				this.AddConfig(config);
			}
			if (Utility.IsStringValid(tableItem.EffectName))
			{
				BuffEffect.BuffEffectConfig config2 = default(BuffEffect.BuffEffectConfig);
				config2.InitWithEffect(tableItem);
				this.AddConfig(config2);
			}
			if (Utility.IsStringValid(tableItem.EffectConfigPath))
			{
				BuffEffect.BuffEffectConfig config3 = default(BuffEffect.BuffEffectConfig);
				config3.InitWithConfig(tableItem.EffectConfigPath);
				this.AddConfig(config3);
			}
			this.hurtEffectName = tableItem.HurtEffectName;
			this.hurtEffectLocator = tableItem.HurtEffectLocateName;
			this.headName = tableItem.HeadName;
			this.sfxID = tableItem.SfxID;
		}
	}

	// Token: 0x060173E8 RID: 95208 RVA: 0x007257A4 File Offset: 0x00723BA4
	public void AddConfig(BuffEffect.BuffEffectConfig config)
	{
		this.configs[this.configNum++] = config;
	}

	// Token: 0x060173E9 RID: 95209 RVA: 0x007257D3 File Offset: 0x00723BD3
	public void ResetDuration(int d)
	{
		if (this.geEffect != null)
		{
			this.geEffect.SetTimeLen(d);
		}
	}

	// Token: 0x060173EA RID: 95210 RVA: 0x007257EC File Offset: 0x00723BEC
	public void ShowHurtEffect()
	{
		if (Utility.IsStringValid(this.hurtEffectName) && this.buff != null)
		{
			this.buff.owner.m_pkGeActor.CreateEffect(this.hurtEffectName, this.hurtEffectLocator, 0f, new Vec3(0f, 0f, 0f), 1f, 1f, false, false, EffectTimeType.SYNC_ANIMATION, false);
		}
	}

	// Token: 0x060173EB RID: 95211 RVA: 0x00725860 File Offset: 0x00723C60
	public void ShowEffect(BeActor actor)
	{
		if (actor == null)
		{
			return;
		}
		this.PlaySfx(this.sfxID);
		if (Utility.IsStringValid(this.headName) && (!actor.buffController.IsAbnormalBuff(this.buff.buffType) || actor.buffController.HasBuffByID(this.buff.buffID) == null))
		{
			string text = this.headName;
			if (text != null)
			{
				ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
				if (clientSystemBattle != null)
				{
					clientSystemBattle.comShowHit.ShowBuffText(text, actor.m_iID, actor.GetGePosition(PositionType.OVERHEAD), this.buff.owner);
				}
			}
		}
		for (int i = 0; i < this.configNum; i++)
		{
			BuffEffectWorkType type = this.configs[i].type;
			if (type != BuffEffectWorkType.SHADER)
			{
				if (type != BuffEffectWorkType.EFFECT)
				{
					if (type != BuffEffectWorkType.CONFIG)
					{
					}
				}
				else if (Utility.IsStringValid(this.configs[i].birthEffect.name))
				{
					GeEffectEx geEffect = this.PlayEffect(this.configs[i].birthEffect, 0, EffectTimeType.SYNC_ANIMATION, false);
					this.buff.TriggerEvent(BeEventType.onBuffCreateEffect, new object[]
					{
						geEffect
					});
					if (geEffect != null)
					{
						float timeLen = geEffect.GetTimeLen();
						BuffEffect.EffectConfig eff = this.configs[i].effect;
						actor.delayCaller.DelayCall(IntMath.Float2Int(timeLen) - 10, delegate
						{
							if (!this.buff.state.IsDead())
							{
								this.geEffect = this.PlayEffect(eff, this.buff.duration, EffectTimeType.BUFF, eff.loop);
								this.buff.TriggerEvent(BeEventType.onBuffReplaceEffect, new object[]
								{
									geEffect,
									this.geEffect
								});
							}
						}, 0, 0, false);
					}
				}
				else
				{
					this.geEffect = this.PlayEffect(this.configs[i].effect, this.buff.duration, EffectTimeType.BUFF, this.configs[i].effect.loop);
					this.buff.TriggerEvent(BeEventType.onBuffCreateEffect, new object[]
					{
						this.geEffect
					});
				}
			}
			else if (this.configs[i].shaderName == "失明")
			{
				if (actor.isLocalActor && !actor.IsDead())
				{
					actor.CurrentBeScene.StartBlindMask();
				}
			}
			else if (this.configs[i].shaderName == "隐身")
			{
				actor.m_pkGeActor.SetShadowVisible(this.buff.owner.CurrentBeScene.currentGeScene, false);
				if (this.recordShaderHandle == 4294967295U)
				{
					this.recordShaderHandle = actor.m_pkGeActor.ChangeSurface(this.configs[i].shaderName, 0f, this.buffEffectAni, true);
				}
				this.visibleHandle = actor.delayCaller.DelayCall(1000, delegate
				{
					actor.m_pkGeActor.SetActorVisible(false);
				}, 0, 0, false);
			}
			else if (this.configs[i].shaderName == "全屏闪白")
			{
				ClientSystemBattle clientSystemBattle2 = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
				if (clientSystemBattle2 != null)
				{
					clientSystemBattle2.ShowFlashWhite();
				}
			}
			else if (this.configs[i].shaderName == "全屏闪白2")
			{
				if (actor.isLocalActor)
				{
					ClientSystemBattle clientSystemBattle3 = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
					if (clientSystemBattle3 != null)
					{
						clientSystemBattle3.ShowFlashWhite();
					}
				}
			}
			else if (this.configs[i].shaderName == "不显示冒字")
			{
				this.showHPNumber = false;
			}
			else
			{
				if (this.configs[i].shaderName == "持续霸体")
				{
					this.buffEffectAni = true;
				}
				if (actor.m_pkGeActor != null && this.recordShaderHandle == 4294967295U)
				{
					this.recordShaderHandle = actor.m_pkGeActor.ChangeSurface(this.configs[i].shaderName, 0f, this.buffEffectAni, true);
				}
			}
		}
	}

	// Token: 0x060173EC RID: 95212 RVA: 0x00725D35 File Offset: 0x00724135
	public void HideEffect()
	{
		if (this.geEffect != null)
		{
			this.geEffect.SetVisible(false);
		}
	}

	// Token: 0x060173ED RID: 95213 RVA: 0x00725D4E File Offset: 0x0072414E
	public void ResetElapsedTime()
	{
		if (this.geEffect != null)
		{
			this.geEffect.ResetElapsedTime();
		}
	}

	// Token: 0x060173EE RID: 95214 RVA: 0x00725D68 File Offset: 0x00724168
	private GeEffectEx PlayEffect(BuffEffect.EffectConfig effect, int duration = 0, EffectTimeType timeType = EffectTimeType.SYNC_ANIMATION, bool loop = false)
	{
		if (this.buff.owner == null)
		{
			return null;
		}
		if (this.buff.owner.m_pkGeActor == null)
		{
			return null;
		}
		DAssetObject effectRes;
		effectRes.m_AssetObj = null;
		effectRes.m_AssetPath = effect.name;
		EffectsFrames effectsFrames = new EffectsFrames();
		effectsFrames.localPosition = new Vector3(0f, 0f, 0f);
		effectsFrames.timetype = timeType;
		if (Utility.IsStringValid(effect.locator))
		{
			effectsFrames.attachname = effect.locator;
		}
		bool forceDisplay = false;
		if (this.buff.buffData != null)
		{
			forceDisplay = this.buff.buffData.IsLowLevelShow;
		}
		float fTime = (float)duration / 1000f;
		return this.buff.owner.m_pkGeActor.CreateEffect(effectRes, effectsFrames, fTime, new Vec3(0f, 0f, 0f), 1f, 1f, loop, false, forceDisplay);
	}

	// Token: 0x060173EF RID: 95215 RVA: 0x00725E64 File Offset: 0x00724264
	public void RemoveEffect(BeActor actor)
	{
		if (actor == null)
		{
			return;
		}
		for (int i = 0; i < this.configNum; i++)
		{
			BuffEffectWorkType type = this.configs[i].type;
			if (type != BuffEffectWorkType.SHADER)
			{
				if (type != BuffEffectWorkType.EFFECT)
				{
					if (type != BuffEffectWorkType.CONFIG)
					{
					}
				}
				else if (this.geEffect != null)
				{
					this.buff.TriggerEvent(BeEventType.onBuffRemoveEffect, new object[]
					{
						this.geEffect
					});
					if (actor.m_pkGeActor != null)
					{
						actor.m_pkGeActor.DestroyEffect(this.geEffect);
					}
					this.geEffect = null;
					if (Utility.IsStringValid(this.configs[i].endEffect.name))
					{
						this.PlayEffect(this.configs[i].endEffect, 0, EffectTimeType.SYNC_ANIMATION, false);
					}
				}
			}
			else if (this.configs[i].shaderName == "失明")
			{
				if (actor.isLocalActor && actor.CurrentBeScene != null)
				{
					actor.CurrentBeScene.StopBlindMask();
				}
			}
			else if (this.configs[i].shaderName == "隐身")
			{
				if (actor.CurrentBeScene != null && actor.m_pkGeActor != null)
				{
					actor.m_pkGeActor.SetShadowVisible(actor.CurrentBeScene.currentGeScene, true);
				}
				if (actor.m_pkGeActor != null)
				{
					actor.m_pkGeActor.RemoveSurface(this.recordShaderHandle);
					this.recordShaderHandle = uint.MaxValue;
				}
				if (actor.m_pkGeActor != null)
				{
					actor.m_pkGeActor.SetActorVisible(true);
				}
				this.visibleHandle.SetRemove(true);
			}
			else if (actor.m_pkGeActor != null)
			{
				actor.m_pkGeActor.RemoveSurface(this.recordShaderHandle);
				this.recordShaderHandle = uint.MaxValue;
			}
		}
		this.StopSfx();
	}

	// Token: 0x060173F0 RID: 95216 RVA: 0x00726059 File Offset: 0x00724459
	public void PlaySfx(int sfxID)
	{
		if (sfxID <= 0)
		{
			return;
		}
		this.audioHandle = MonoSingleton<AudioManager>.instance.PlaySound(sfxID);
	}

	// Token: 0x060173F1 RID: 95217 RVA: 0x00726074 File Offset: 0x00724474
	public void StopSfx()
	{
		if (this.audioHandle > 0U)
		{
			MonoSingleton<AudioManager>.instance.Stop(this.audioHandle);
			this.audioHandle = 0U;
		}
	}

	// Token: 0x04010B9E RID: 68510
	private BuffEffect.BuffEffectConfig[] configs = new BuffEffect.BuffEffectConfig[5];

	// Token: 0x04010B9F RID: 68511
	public int configNum;

	// Token: 0x04010BA0 RID: 68512
	private bool buffEffectAni = true;

	// Token: 0x04010BA1 RID: 68513
	public BeBuff buff;

	// Token: 0x04010BA2 RID: 68514
	public GeEffectEx geEffect;

	// Token: 0x04010BA3 RID: 68515
	public string hurtEffectName;

	// Token: 0x04010BA4 RID: 68516
	public string hurtEffectLocator;

	// Token: 0x04010BA5 RID: 68517
	private uint recordShaderHandle = uint.MaxValue;

	// Token: 0x04010BA6 RID: 68518
	public string headName;

	// Token: 0x04010BA7 RID: 68519
	public bool showHPNumber = true;

	// Token: 0x04010BA8 RID: 68520
	private uint audioHandle;

	// Token: 0x04010BA9 RID: 68521
	private int sfxID;

	// Token: 0x04010BAA RID: 68522
	private DelayCallUnitHandle visibleHandle;

	// Token: 0x020041CF RID: 16847
	public struct EffectConfig
	{
		// Token: 0x04010BAB RID: 68523
		public string name;

		// Token: 0x04010BAC RID: 68524
		public string locator;

		// Token: 0x04010BAD RID: 68525
		public bool loop;
	}

	// Token: 0x020041D0 RID: 16848
	public struct BuffEffectConfig
	{
		// Token: 0x060173F2 RID: 95218 RVA: 0x00726099 File Offset: 0x00724499
		public void InitWithShader(string name)
		{
			this.type = BuffEffectWorkType.SHADER;
			this.shaderName = name;
		}

		// Token: 0x060173F3 RID: 95219 RVA: 0x007260AC File Offset: 0x007244AC
		public void InitWithEffect(BuffTable data)
		{
			this.type = BuffEffectWorkType.EFFECT;
			this.birthEffect.name = data.BirthEffect;
			this.birthEffect.locator = data.BirthEffectLocate;
			this.effect.name = data.EffectName;
			this.effect.locator = data.EffectLocateName;
			this.effect.loop = !data.EffectLoop;
			this.endEffect.name = data.EndEffect;
			this.endEffect.locator = data.EndEffectLocate;
		}

		// Token: 0x060173F4 RID: 95220 RVA: 0x0072613A File Offset: 0x0072453A
		public void InitWithConfig(string path)
		{
			this.type = BuffEffectWorkType.CONFIG;
			this.effectConfigPath = path;
		}

		// Token: 0x04010BAE RID: 68526
		public BuffEffectWorkType type;

		// Token: 0x04010BAF RID: 68527
		public string shaderName;

		// Token: 0x04010BB0 RID: 68528
		public BuffEffect.EffectConfig birthEffect;

		// Token: 0x04010BB1 RID: 68529
		public BuffEffect.EffectConfig effect;

		// Token: 0x04010BB2 RID: 68530
		public BuffEffect.EffectConfig endEffect;

		// Token: 0x04010BB3 RID: 68531
		public string effectConfigPath;
	}
}
