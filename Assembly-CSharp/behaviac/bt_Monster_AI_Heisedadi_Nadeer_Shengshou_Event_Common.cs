using System;

namespace behaviac
{
	// Token: 0x0200354C RID: 13644
	public static class bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common
	{
		// Token: 0x060152D9 RID: 86745 RVA: 0x00661EC8 File Offset: 0x006602C8
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Heisedadi/Nadeer_Shengshou_Event_Common");
			bt.IsFSM = false;
			Parallel_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node1 parallel_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node = new Parallel_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node1();
			parallel_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node.SetClassNameString("Parallel");
			parallel_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node.SetId(1);
			bt.AddChild(parallel_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(2);
			parallel_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node.AddChild(sequence);
			Condition_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node0 condition_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node = new Condition_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node0();
			condition_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node.SetId(0);
			sequence.AddChild(condition_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node.HasEvents());
			Action_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node3 action_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node = new Action_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node3();
			action_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node.SetClassNameString("Action");
			action_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node.SetId(3);
			sequence.AddChild(action_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node.HasEvents());
			parallel_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node.SetHasEvents(parallel_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(4);
			parallel_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node.AddChild(sequence2);
			Condition_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node5 condition_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node2 = new Condition_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node5();
			condition_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node2.SetId(5);
			sequence2.AddChild(condition_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node2.HasEvents());
			Action_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node6 action_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node2 = new Action_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node6();
			action_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node2.SetId(6);
			sequence2.AddChild(action_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node2.HasEvents());
			parallel_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node.SetHasEvents(parallel_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node.HasEvents() | sequence2.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(7);
			parallel_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node.AddChild(sequence3);
			Condition_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node8 condition_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node3 = new Condition_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node8();
			condition_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node3.SetId(8);
			sequence3.AddChild(condition_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node3.HasEvents());
			Action_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node9 action_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node3 = new Action_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node9();
			action_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node3.SetClassNameString("Action");
			action_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node3.SetId(9);
			sequence3.AddChild(action_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node3.HasEvents());
			parallel_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node.SetHasEvents(parallel_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node.HasEvents() | sequence3.HasEvents());
			Sequence sequence4 = new Sequence();
			sequence4.SetClassNameString("Sequence");
			sequence4.SetId(10);
			parallel_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node.AddChild(sequence4);
			Condition_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node11 condition_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node4 = new Condition_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node11();
			condition_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node4.SetId(11);
			sequence4.AddChild(condition_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node4);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node4.HasEvents());
			Action_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node12 action_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node4 = new Action_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node12();
			action_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node4.SetClassNameString("Action");
			action_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node4.SetId(12);
			sequence4.AddChild(action_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node4);
			sequence4.SetHasEvents(sequence4.HasEvents() | action_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node4.HasEvents());
			parallel_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node.SetHasEvents(parallel_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node.HasEvents() | sequence4.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | parallel_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node.HasEvents());
			return true;
		}
	}
}
