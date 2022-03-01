using System;

namespace behaviac
{
	// Token: 0x0200335B RID: 13147
	public static class bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event
	{
		// Token: 0x06014F16 RID: 85782 RVA: 0x0064F538 File Offset: 0x0064D938
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/GoblinKingdom/Goblin_qinweidui_hanhua_Event");
			bt.IsFSM = false;
			Parallel_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node2 parallel_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node = new Parallel_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node2();
			parallel_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node.SetClassNameString("Parallel");
			parallel_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node.SetId(2);
			bt.AddChild(parallel_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(3);
			parallel_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node.AddChild(sequence);
			Condition_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node0 condition_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node = new Condition_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node0();
			condition_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node.SetId(0);
			sequence.AddChild(condition_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node.HasEvents());
			Action_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node11 action_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node = new Action_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node11();
			action_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node.SetId(11);
			sequence.AddChild(action_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node.HasEvents());
			Condition_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node9 condition_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node2 = new Condition_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node9();
			condition_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node2.SetId(9);
			sequence.AddChild(condition_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node2.HasEvents());
			Action_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node1 action_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node2 = new Action_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node1();
			action_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node2.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node2.SetId(1);
			sequence.AddChild(action_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node2.HasEvents());
			parallel_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node.SetHasEvents(parallel_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(5);
			parallel_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node.AddChild(sequence2);
			Condition_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node6 condition_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node3 = new Condition_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node6();
			condition_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node3.SetId(6);
			sequence2.AddChild(condition_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node3.HasEvents());
			Action_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node4 action_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node3 = new Action_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node4();
			action_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node3.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node3.SetId(4);
			sequence2.AddChild(action_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node3.HasEvents());
			Condition_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node10 condition_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node4 = new Condition_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node10();
			condition_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node4.SetId(10);
			sequence2.AddChild(condition_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node4.HasEvents());
			Action_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node8 action_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node4 = new Action_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node8();
			action_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node4.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node4.SetId(8);
			sequence2.AddChild(action_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node4.HasEvents());
			parallel_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node.SetHasEvents(parallel_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node.HasEvents() | sequence2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | parallel_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node.HasEvents());
			return true;
		}
	}
}
