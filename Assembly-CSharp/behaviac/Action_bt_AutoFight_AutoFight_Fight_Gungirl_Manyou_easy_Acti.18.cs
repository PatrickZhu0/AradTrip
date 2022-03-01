using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001FE2 RID: 8162
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node45 : Action
	{
		// Token: 0x06012961 RID: 76129 RVA: 0x00572228 File Offset: 0x00570628
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node45()
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
			item.skillID = 2507;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012962 RID: 76130 RVA: 0x005722B8 File Offset: 0x005706B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C353 RID: 50003
		private List<Input> method_p0;

		// Token: 0x0400C354 RID: 50004
		private bool method_p1;
	}
}
