using System;

namespace behaviac
{
	// Token: 0x02002591 RID: 9617
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Action_node56 : Condition
	{
		// Token: 0x0601346A RID: 78954 RVA: 0x005BAD4E File Offset: 0x005B914E
		public Condition_bt_AutoFight_AutoFight_Gunman_Action_node56()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x0601346B RID: 78955 RVA: 0x005BAD64 File Offset: 0x005B9164
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE96 RID: 52886
		private float opl_p0;
	}
}
