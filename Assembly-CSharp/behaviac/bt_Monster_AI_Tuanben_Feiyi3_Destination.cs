using System;

namespace behaviac
{
	// Token: 0x020039BB RID: 14779
	public static class bt_Monster_AI_Tuanben_Feiyi3_Destination
	{
		// Token: 0x06015B49 RID: 88905 RVA: 0x0068E22C File Offset: 0x0068C62C
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Tuanben/Feiyi3_Destination");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(18);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(11);
			selector.AddChild(sequence);
			Condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node0 condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node = new Condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node0();
			condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node.SetId(0);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node.HasEvents());
			Action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node10 action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node = new Action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node10();
			action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node.SetId(10);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node.HasEvents());
			Compute_bt_Monster_AI_Tuanben_Feiyi3_Destination_node4 compute_bt_Monster_AI_Tuanben_Feiyi3_Destination_node = new Compute_bt_Monster_AI_Tuanben_Feiyi3_Destination_node4();
			compute_bt_Monster_AI_Tuanben_Feiyi3_Destination_node.SetClassNameString("Compute");
			compute_bt_Monster_AI_Tuanben_Feiyi3_Destination_node.SetId(4);
			sequence.AddChild(compute_bt_Monster_AI_Tuanben_Feiyi3_Destination_node);
			sequence.SetHasEvents(sequence.HasEvents() | compute_bt_Monster_AI_Tuanben_Feiyi3_Destination_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(1);
			selector.AddChild(sequence2);
			Condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node5 condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node2 = new Condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node5();
			condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node2.SetId(5);
			sequence2.AddChild(condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node2.HasEvents());
			Action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node6 action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node2 = new Action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node6();
			action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node2.SetId(6);
			sequence2.AddChild(action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node2.HasEvents());
			Compute_bt_Monster_AI_Tuanben_Feiyi3_Destination_node8 compute_bt_Monster_AI_Tuanben_Feiyi3_Destination_node2 = new Compute_bt_Monster_AI_Tuanben_Feiyi3_Destination_node8();
			compute_bt_Monster_AI_Tuanben_Feiyi3_Destination_node2.SetClassNameString("Compute");
			compute_bt_Monster_AI_Tuanben_Feiyi3_Destination_node2.SetId(8);
			sequence2.AddChild(compute_bt_Monster_AI_Tuanben_Feiyi3_Destination_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | compute_bt_Monster_AI_Tuanben_Feiyi3_Destination_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(9);
			selector.AddChild(sequence3);
			Condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node12 condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node3 = new Condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node12();
			condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node3.SetId(12);
			sequence3.AddChild(condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node3.HasEvents());
			Compute_bt_Monster_AI_Tuanben_Feiyi3_Destination_node16 compute_bt_Monster_AI_Tuanben_Feiyi3_Destination_node3 = new Compute_bt_Monster_AI_Tuanben_Feiyi3_Destination_node16();
			compute_bt_Monster_AI_Tuanben_Feiyi3_Destination_node3.SetClassNameString("Compute");
			compute_bt_Monster_AI_Tuanben_Feiyi3_Destination_node3.SetId(16);
			sequence3.AddChild(compute_bt_Monster_AI_Tuanben_Feiyi3_Destination_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | compute_bt_Monster_AI_Tuanben_Feiyi3_Destination_node3.HasEvents());
			Action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node14 action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node3 = new Action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node14();
			action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node3.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node3.SetId(14);
			sequence3.AddChild(action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node3.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence3.HasEvents());
			Sequence sequence4 = new Sequence();
			sequence4.SetClassNameString("Sequence");
			sequence4.SetId(13);
			selector.AddChild(sequence4);
			Condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node3 condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node4 = new Condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node3();
			condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node4.SetId(3);
			sequence4.AddChild(condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node4);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node4.HasEvents());
			Action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node15 action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node4 = new Action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node15();
			action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node4.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node4.SetId(15);
			sequence4.AddChild(action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node4);
			sequence4.SetHasEvents(sequence4.HasEvents() | action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node4.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence4.HasEvents());
			Sequence sequence5 = new Sequence();
			sequence5.SetClassNameString("Sequence");
			sequence5.SetId(19);
			selector.AddChild(sequence5);
			Condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node20 condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node5 = new Condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node20();
			condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node5.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node5.SetId(20);
			sequence5.AddChild(condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node5);
			sequence5.SetHasEvents(sequence5.HasEvents() | condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node5.HasEvents());
			Action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node23 action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node5 = new Action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node23();
			action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node5.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node5.SetId(23);
			sequence5.AddChild(action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node5);
			sequence5.SetHasEvents(sequence5.HasEvents() | action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node5.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence5.HasEvents());
			Sequence sequence6 = new Sequence();
			sequence6.SetClassNameString("Sequence");
			sequence6.SetId(24);
			selector.AddChild(sequence6);
			Condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node25 condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node6 = new Condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node25();
			condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node6.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node6.SetId(25);
			sequence6.AddChild(condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node6);
			sequence6.SetHasEvents(sequence6.HasEvents() | condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node6.HasEvents());
			Action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node27 action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node6 = new Action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node27();
			action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node6.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node6.SetId(27);
			sequence6.AddChild(action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node6);
			sequence6.SetHasEvents(sequence6.HasEvents() | action_bt_Monster_AI_Tuanben_Feiyi3_Destination_node6.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence6.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
