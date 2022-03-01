using System;

namespace behaviac
{
	// Token: 0x0200355E RID: 13662
	public static class bt_Monster_AI_Heisedadi_Zhaohuan_Event_01
	{
		// Token: 0x060152F9 RID: 86777 RVA: 0x00662A30 File Offset: 0x00660E30
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Heisedadi/Zhaohuan_Event_01");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_01_node1 action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_01_node = new Action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_01_node1();
			action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_01_node.SetClassNameString("Action");
			action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_01_node.SetId(1);
			sequence.AddChild(action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_01_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_01_node.HasEvents());
			Action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_01_node2 action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_01_node2 = new Action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_01_node2();
			action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_01_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_01_node2.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_01_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_01_node2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
