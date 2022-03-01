using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001EFD RID: 7933
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node46 : Action
	{
		// Token: 0x0601279E RID: 75678 RVA: 0x00567E98 File Offset: 0x00566298
		public Action_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node46()
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
			item.skillID = 3116;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601279F RID: 75679 RVA: 0x00567F28 File Offset: 0x00566328
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C192 RID: 49554
		private List<Input> method_p0;

		// Token: 0x0400C193 RID: 49555
		private bool method_p1;
	}
}
