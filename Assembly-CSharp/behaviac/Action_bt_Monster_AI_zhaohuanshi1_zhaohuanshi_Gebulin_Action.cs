using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004039 RID: 16441
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node8 : Action
	{
		// Token: 0x060167D1 RID: 92113 RVA: 0x006CE97C File Offset: 0x006CCD7C
		public Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node8()
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
			item.skillID = 5109;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060167D2 RID: 92114 RVA: 0x006CEA0C File Offset: 0x006CCE0C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0401001C RID: 65564
		private List<Input> method_p0;

		// Token: 0x0401001D RID: 65565
		private bool method_p1;
	}
}
