using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003E69 RID: 15977
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Xielong_Xielong_Event_yongshi_node11 : Action
	{
		// Token: 0x06016455 RID: 91221 RVA: 0x006BBC6C File Offset: 0x006BA06C
		public Action_bt_Monster_AI_Xielong_Xielong_Event_yongshi_node11()
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
			item.skillID = 7227;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06016456 RID: 91222 RVA: 0x006BBCFC File Offset: 0x006BA0FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC96 RID: 64662
		private List<Input> method_p0;

		// Token: 0x0400FC97 RID: 64663
		private bool method_p1;
	}
}
