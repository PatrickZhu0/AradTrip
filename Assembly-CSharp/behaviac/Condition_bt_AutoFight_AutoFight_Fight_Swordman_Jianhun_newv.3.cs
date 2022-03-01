using System;

namespace behaviac
{
	// Token: 0x020022B1 RID: 8881
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node59 : Condition
	{
		// Token: 0x06012EDD RID: 77533 RVA: 0x0059609D File Offset: 0x0059449D
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node59()
		{
			this.opl_p0 = 1906;
		}

		// Token: 0x06012EDE RID: 77534 RVA: 0x005960B0 File Offset: 0x005944B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C8EC RID: 51436
		private int opl_p0;
	}
}
