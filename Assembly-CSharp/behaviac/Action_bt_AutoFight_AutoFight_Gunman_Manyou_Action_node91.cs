using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002624 RID: 9764
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node91 : Action
	{
		// Token: 0x0601358E RID: 79246 RVA: 0x005C1514 File Offset: 0x005BF914
		public Action_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node91()
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
			item.skillID = 1007;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = true;
		}

		// Token: 0x0601358F RID: 79247 RVA: 0x005C15A4 File Offset: 0x005BF9A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFDC RID: 53212
		private List<Input> method_p0;

		// Token: 0x0400CFDD RID: 53213
		private bool method_p1;
	}
}
