using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020039E5 RID: 14821
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node9 : Action
	{
		// Token: 0x06015B9A RID: 88986 RVA: 0x0068F850 File Offset: 0x0068DC50
		public Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node9()
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
			item.skillID = 21073;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015B9B RID: 88987 RVA: 0x0068F8E0 File Offset: 0x0068DCE0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4DA RID: 62682
		private List<Input> method_p0;

		// Token: 0x0400F4DB RID: 62683
		private bool method_p1;
	}
}
