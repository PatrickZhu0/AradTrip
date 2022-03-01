using System;

namespace behaviac
{
	// Token: 0x02002735 RID: 10037
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node25 : Condition
	{
		// Token: 0x060137AC RID: 79788 RVA: 0x005CD605 File Offset: 0x005CBA05
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node25()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060137AD RID: 79789 RVA: 0x005CD618 File Offset: 0x005CBA18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D207 RID: 53767
		private float opl_p0;
	}
}
