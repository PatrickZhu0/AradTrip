using System;

namespace behaviac
{
	// Token: 0x02002DF5 RID: 11765
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node52 : Condition
	{
		// Token: 0x060144C7 RID: 83143 RVA: 0x006190D3 File Offset: 0x006174D3
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node52()
		{
			this.opl_p0 = 21633;
		}

		// Token: 0x060144C8 RID: 83144 RVA: 0x006190E8 File Offset: 0x006174E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE7E RID: 56958
		private int opl_p0;
	}
}
