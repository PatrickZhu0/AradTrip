using System;

namespace behaviac
{
	// Token: 0x02003A6F RID: 14959
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node87 : Condition
	{
		// Token: 0x06015CA7 RID: 89255 RVA: 0x006948DB File Offset: 0x00692CDB
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node87()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570034;
		}

		// Token: 0x06015CA8 RID: 89256 RVA: 0x006948FC File Offset: 0x00692CFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F5DC RID: 62940
		private BE_Target opl_p0;

		// Token: 0x0400F5DD RID: 62941
		private BE_Equal opl_p1;

		// Token: 0x0400F5DE RID: 62942
		private int opl_p2;
	}
}
