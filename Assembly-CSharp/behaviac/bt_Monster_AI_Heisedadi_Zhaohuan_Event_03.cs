using System;

namespace behaviac
{
	// Token: 0x02003564 RID: 13668
	public static class bt_Monster_AI_Heisedadi_Zhaohuan_Event_03
	{
		// Token: 0x06015303 RID: 86787 RVA: 0x00662D20 File Offset: 0x00661120
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Heisedadi/Zhaohuan_Event_03");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_03_node1 action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_03_node = new Action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_03_node1();
			action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_03_node.SetClassNameString("Action");
			action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_03_node.SetId(1);
			sequence.AddChild(action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_03_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_03_node.HasEvents());
			Action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_03_node2 action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_03_node2 = new Action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_03_node2();
			action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_03_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_03_node2.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_03_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_03_node2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
