using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003803 RID: 14339
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node3 : Action
	{
		// Token: 0x060157F7 RID: 88055 RVA: 0x0067CFB4 File Offset: 0x0067B3B4
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node3()
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

		// Token: 0x060157F8 RID: 88056 RVA: 0x0067D044 File Offset: 0x0067B444
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F1C1 RID: 61889
		private List<Input> method_p0;

		// Token: 0x0400F1C2 RID: 61890
		private bool method_p1;
	}
}
