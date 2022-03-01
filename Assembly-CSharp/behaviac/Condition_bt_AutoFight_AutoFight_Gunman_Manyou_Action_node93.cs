using System;

namespace behaviac
{
	// Token: 0x020025F3 RID: 9715
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node93 : Condition
	{
		// Token: 0x0601352C RID: 79148 RVA: 0x005BFEF6 File Offset: 0x005BE2F6
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node93()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 110801;
		}

		// Token: 0x0601352D RID: 79149 RVA: 0x005BFF18 File Offset: 0x005BE318
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF72 RID: 53106
		private BE_Target opl_p0;

		// Token: 0x0400CF73 RID: 53107
		private BE_Equal opl_p1;

		// Token: 0x0400CF74 RID: 53108
		private int opl_p2;
	}
}
