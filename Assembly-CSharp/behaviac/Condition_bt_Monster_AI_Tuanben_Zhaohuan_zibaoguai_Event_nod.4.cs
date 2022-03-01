using System;

namespace behaviac
{
	// Token: 0x02003B7F RID: 15231
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node8 : Condition
	{
		// Token: 0x06015EB0 RID: 89776 RVA: 0x0069F8AB File Offset: 0x0069DCAB
		public Condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node8()
		{
			this.opl_p0 = 21402;
		}

		// Token: 0x06015EB1 RID: 89777 RVA: 0x0069F8C0 File Offset: 0x0069DCC0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F774 RID: 63348
		private int opl_p0;
	}
}
