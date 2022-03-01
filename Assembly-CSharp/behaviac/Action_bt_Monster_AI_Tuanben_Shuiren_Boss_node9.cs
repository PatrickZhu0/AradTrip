using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003B1E RID: 15134
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Shuiren_Boss_node9 : Action
	{
		// Token: 0x06015DF4 RID: 89588 RVA: 0x0069BDFC File Offset: 0x0069A1FC
		public Action_bt_Monster_AI_Tuanben_Shuiren_Boss_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 80170011;
			this.method_p1 = new List<int>();
			this.method_p1.Capacity = 3;
			int item = -5000;
			this.method_p1.Add(item);
			int item2 = 7000;
			this.method_p1.Add(item2);
			int item3 = 5000;
			this.method_p1.Add(item3);
			this.method_p2 = true;
			this.method_p3 = 60;
		}

		// Token: 0x06015DF5 RID: 89589 RVA: 0x0069BE7D File Offset: 0x0069A27D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_Summon(this.method_p0, this.method_p1, this.method_p2, this.method_p3);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6DA RID: 63194
		private int method_p0;

		// Token: 0x0400F6DB RID: 63195
		private List<int> method_p1;

		// Token: 0x0400F6DC RID: 63196
		private bool method_p2;

		// Token: 0x0400F6DD RID: 63197
		private int method_p3;
	}
}
