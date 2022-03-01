using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002581 RID: 9601
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Action_node34 : Action
	{
		// Token: 0x0601344A RID: 78922 RVA: 0x005BA4F4 File Offset: 0x005B88F4
		public Action_bt_AutoFight_AutoFight_Gunman_Action_node34()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 200;
			item.randomChangeDirection = false;
			item.skillID = 1204;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601344B RID: 78923 RVA: 0x005BA588 File Offset: 0x005B8988
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE73 RID: 52851
		private List<Input> method_p0;

		// Token: 0x0400CE74 RID: 52852
		private bool method_p1;
	}
}
