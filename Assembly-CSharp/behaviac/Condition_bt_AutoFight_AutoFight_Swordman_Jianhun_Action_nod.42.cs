using System;

namespace behaviac
{
	// Token: 0x0200293C RID: 10556
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node27 : Condition
	{
		// Token: 0x06013BAE RID: 80814 RVA: 0x005E55B7 File Offset: 0x005E39B7
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node27()
		{
			this.opl_p0 = 1514;
		}

		// Token: 0x06013BAF RID: 80815 RVA: 0x005E55CC File Offset: 0x005E39CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D614 RID: 54804
		private int opl_p0;
	}
}
