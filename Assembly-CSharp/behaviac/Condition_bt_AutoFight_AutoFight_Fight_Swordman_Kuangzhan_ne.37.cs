using System;

namespace behaviac
{
	// Token: 0x020023C2 RID: 9154
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node52 : Condition
	{
		// Token: 0x060130EA RID: 78058 RVA: 0x005A53E1 File Offset: 0x005A37E1
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node52()
		{
			this.opl_p0 = 1604;
		}

		// Token: 0x060130EB RID: 78059 RVA: 0x005A53F4 File Offset: 0x005A37F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB1D RID: 51997
		private int opl_p0;
	}
}
