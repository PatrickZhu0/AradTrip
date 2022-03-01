using System;

namespace behaviac
{
	// Token: 0x02002817 RID: 10263
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node56 : Condition
	{
		// Token: 0x0601396C RID: 80236 RVA: 0x005D86F6 File Offset: 0x005D6AF6
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node56()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 370900;
		}

		// Token: 0x0601396D RID: 80237 RVA: 0x005D8718 File Offset: 0x005D6B18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3C9 RID: 54217
		private BE_Target opl_p0;

		// Token: 0x0400D3CA RID: 54218
		private BE_Equal opl_p1;

		// Token: 0x0400D3CB RID: 54219
		private int opl_p2;
	}
}
