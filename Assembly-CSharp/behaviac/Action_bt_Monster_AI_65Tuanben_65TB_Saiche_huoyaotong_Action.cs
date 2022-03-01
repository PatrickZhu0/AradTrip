using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002BC4 RID: 11204
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_huoyaotong_Action_node2 : Action
	{
		// Token: 0x0601408B RID: 82059 RVA: 0x00604758 File Offset: 0x00602B58
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_huoyaotong_Action_node2()
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
			item.skillID = 21843;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601408C RID: 82060 RVA: 0x006047E8 File Offset: 0x00602BE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA7A RID: 55930
		private List<Input> method_p0;

		// Token: 0x0400DA7B RID: 55931
		private bool method_p1;
	}
}
