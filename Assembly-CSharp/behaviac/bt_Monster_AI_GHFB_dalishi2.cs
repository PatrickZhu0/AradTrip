using System;

namespace behaviac
{
	// Token: 0x020032B5 RID: 12981
	public static class bt_Monster_AI_GHFB_dalishi2
	{
		// Token: 0x06014DDF RID: 85471 RVA: 0x006491B0 File Offset: 0x006475B0
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/GHFB/dalishi2");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Action_bt_Monster_AI_GHFB_dalishi2_node4 action_bt_Monster_AI_GHFB_dalishi2_node = new Action_bt_Monster_AI_GHFB_dalishi2_node4();
			action_bt_Monster_AI_GHFB_dalishi2_node.SetClassNameString("Action");
			action_bt_Monster_AI_GHFB_dalishi2_node.SetId(4);
			sequence.AddChild(action_bt_Monster_AI_GHFB_dalishi2_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_GHFB_dalishi2_node.HasEvents());
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(13);
			sequence.AddChild(selector);
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(2);
			selector.AddChild(sequence2);
			Condition_bt_Monster_AI_GHFB_dalishi2_node10 condition_bt_Monster_AI_GHFB_dalishi2_node = new Condition_bt_Monster_AI_GHFB_dalishi2_node10();
			condition_bt_Monster_AI_GHFB_dalishi2_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_GHFB_dalishi2_node.SetId(10);
			sequence2.AddChild(condition_bt_Monster_AI_GHFB_dalishi2_node);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_GHFB_dalishi2_node.HasEvents());
			Action_bt_Monster_AI_GHFB_dalishi2_node1 action_bt_Monster_AI_GHFB_dalishi2_node2 = new Action_bt_Monster_AI_GHFB_dalishi2_node1();
			action_bt_Monster_AI_GHFB_dalishi2_node2.SetClassNameString("Action");
			action_bt_Monster_AI_GHFB_dalishi2_node2.SetId(1);
			sequence2.AddChild(action_bt_Monster_AI_GHFB_dalishi2_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_GHFB_dalishi2_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(11);
			selector.AddChild(sequence3);
			Condition_bt_Monster_AI_GHFB_dalishi2_node6 condition_bt_Monster_AI_GHFB_dalishi2_node2 = new Condition_bt_Monster_AI_GHFB_dalishi2_node6();
			condition_bt_Monster_AI_GHFB_dalishi2_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_GHFB_dalishi2_node2.SetId(6);
			sequence3.AddChild(condition_bt_Monster_AI_GHFB_dalishi2_node2);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_GHFB_dalishi2_node2.HasEvents());
			Action_bt_Monster_AI_GHFB_dalishi2_node5 action_bt_Monster_AI_GHFB_dalishi2_node3 = new Action_bt_Monster_AI_GHFB_dalishi2_node5();
			action_bt_Monster_AI_GHFB_dalishi2_node3.SetClassNameString("Action");
			action_bt_Monster_AI_GHFB_dalishi2_node3.SetId(5);
			sequence3.AddChild(action_bt_Monster_AI_GHFB_dalishi2_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_GHFB_dalishi2_node3.HasEvents());
			Condition_bt_Monster_AI_GHFB_dalishi2_node8 condition_bt_Monster_AI_GHFB_dalishi2_node3 = new Condition_bt_Monster_AI_GHFB_dalishi2_node8();
			condition_bt_Monster_AI_GHFB_dalishi2_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_GHFB_dalishi2_node3.SetId(8);
			sequence3.AddChild(condition_bt_Monster_AI_GHFB_dalishi2_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_GHFB_dalishi2_node3.HasEvents());
			Action_bt_Monster_AI_GHFB_dalishi2_node3 action_bt_Monster_AI_GHFB_dalishi2_node4 = new Action_bt_Monster_AI_GHFB_dalishi2_node3();
			action_bt_Monster_AI_GHFB_dalishi2_node4.SetClassNameString("Action");
			action_bt_Monster_AI_GHFB_dalishi2_node4.SetId(3);
			sequence3.AddChild(action_bt_Monster_AI_GHFB_dalishi2_node4);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_GHFB_dalishi2_node4.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence3.HasEvents());
			sequence.SetHasEvents(sequence.HasEvents() | selector.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
