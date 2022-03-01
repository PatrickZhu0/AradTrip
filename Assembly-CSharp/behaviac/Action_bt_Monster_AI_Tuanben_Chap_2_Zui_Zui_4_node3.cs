using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200380E RID: 14350
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node3 : Action
	{
		// Token: 0x0601580B RID: 88075 RVA: 0x0067D5E8 File Offset: 0x0067B9E8
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_4_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 21200;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601580C RID: 88076 RVA: 0x0067D678 File Offset: 0x0067BA78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F1D3 RID: 61907
		private List<Input> method_p0;

		// Token: 0x0400F1D4 RID: 61908
		private bool method_p1;
	}
}
