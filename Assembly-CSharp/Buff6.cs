using System;
using GameClient;

// Token: 0x0200422C RID: 16940
public class Buff6 : BeAbnormalBuff
{
	// Token: 0x06017737 RID: 96055 RVA: 0x00734AA5 File Offset: 0x00732EA5
	public Buff6(int bi, int buffLevel, int buffDuration, int attack = 0) : base(bi, buffLevel, buffDuration, attack, true)
	{
	}

	// Token: 0x06017738 RID: 96056 RVA: 0x00734AB3 File Offset: 0x00732EB3
	public override void OnStart()
	{
		base.OnStart();
		this.RemoveHanlder();
		this.handler = base.owner.RegisterEvent(BeEventType.onHitAfterAddBuff, delegate(object[] args)
		{
			if (args != null && args[1] != null)
			{
				BeActor obj = args[2] as BeActor;
				bool flag = (bool)args[1];
				if (flag)
				{
					if (this.overlayType == BuffOverlayType.OVERLAY_DAMAGE)
					{
						this.DoWorkForInterval();
					}
					else if (this.overlayType == BuffOverlayType.OVERLAY_ALONE && this.abnormalBuffData.isFirst)
					{
						int num = base.owner.buffController.GetAbnormalDamage(this.buffID);
						if (num > 0)
						{
							this.interParams[0] = this;
							int[] array = this.interParams[1] as int[];
							array[0] = num;
							base.owner.TriggerEvent(BeEventType.AbnormalBuffHurt, this.interParams);
							num = array[0];
							if (base.owner.CurrentBeScene != null)
							{
								base.owner.CurrentBeScene.TriggerEvent(BeEventSceneType.onHurtByAbnormalBuff, new object[]
								{
									num,
									base.releaser,
									base.owner,
									this.skillId
								});
								EventParam eventParam = base.owner.CurrentBeScene.TriggerEventNew(BeEventSceneType.onElectricBuffHurt, new EventParam
								{
									m_Int = 0,
									m_Obj = base.releaser,
									m_Obj2 = obj
								});
								if (eventParam.m_Int != 0)
								{
									num *= VFactor.one + VFactor.NewVFactor(eventParam.m_Int, 1000);
								}
							}
							base.DoBuffAttack(num);
						}
					}
				}
			}
		});
	}

	// Token: 0x06017739 RID: 96057 RVA: 0x00734AE0 File Offset: 0x00732EE0
	public override void OnFinish()
	{
		base.OnFinish();
		this.RemoveHanlder();
	}

	// Token: 0x0601773A RID: 96058 RVA: 0x00734AEE File Offset: 0x00732EEE
	private void RemoveHanlder()
	{
		if (this.handler != null)
		{
			this.handler.Remove();
			this.handler = null;
		}
	}

	// Token: 0x04010D60 RID: 68960
	private BeEventHandle handler;
}
