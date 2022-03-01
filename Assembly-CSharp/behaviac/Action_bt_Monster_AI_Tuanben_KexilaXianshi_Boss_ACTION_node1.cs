using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003A43 RID: 14915
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node12 : Action
	{
		// Token: 0x06015C4F RID: 89167 RVA: 0x006935B8 File Offset: 0x006919B8
		public Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node12()
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
			item.skillID = 21059;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015C50 RID: 89168 RVA: 0x00693648 File Offset: 0x00691A48
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F56E RID: 62830
		private List<Input> method_p0;

		// Token: 0x0400F56F RID: 62831
		private bool method_p1;
	}
}
