using System;

namespace behaviac
{
	// Token: 0x02002F22 RID: 12066
	public static class bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT
	{
		// Token: 0x0601471A RID: 83738 RVA: 0x00626634 File Offset: 0x00624A34
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/65Tuanben/Jihunzhe_Boss_EVENT");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(16);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(25);
			selector.AddChild(sequence);
			Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node36 condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node = new Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node36();
			condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node.SetId(36);
			sequence.AddChild(condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node.HasEvents());
			Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node31 condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node2 = new Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node31();
			condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node2.SetId(31);
			sequence.AddChild(condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node2.HasEvents());
			Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node28 action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node = new Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node28();
			action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node.SetId(28);
			sequence.AddChild(action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node.HasEvents());
			Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node32 action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node2 = new Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node32();
			action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node2.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node2.SetId(32);
			sequence.AddChild(action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(30);
			selector.AddChild(sequence2);
			Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node27 condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node3 = new Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node27();
			condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node3.SetId(27);
			sequence2.AddChild(condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node3.HasEvents());
			Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node26 action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node3 = new Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node26();
			action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node3.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node3.SetId(26);
			sequence2.AddChild(action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node3.HasEvents());
			Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node33 action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node4 = new Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node33();
			action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node4.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node4.SetId(33);
			sequence2.AddChild(action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node4.HasEvents());
			Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node34 action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node5 = new Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node34();
			action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node5.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node5.SetId(34);
			sequence2.AddChild(action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node5);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node5.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
