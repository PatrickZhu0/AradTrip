using System;

namespace behaviac
{
	// Token: 0x02002BB0 RID: 11184
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node8 : Condition
	{
		// Token: 0x06014067 RID: 82023 RVA: 0x00603AFD File Offset: 0x00601EFD
		public Condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Action_node8()
		{
			this.opl_p0 = 20773;
		}

		// Token: 0x06014068 RID: 82024 RVA: 0x00603B10 File Offset: 0x00601F10
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA61 RID: 55905
		private int opl_p0;
	}
}
