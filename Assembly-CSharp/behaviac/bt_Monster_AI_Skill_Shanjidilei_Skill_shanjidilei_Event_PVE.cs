using System;

namespace behaviac
{
	// Token: 0x02003748 RID: 14152
	public static class bt_Monster_AI_Skill_Shanjidilei_Skill_shanjidilei_Event_PVE
	{
		// Token: 0x06015699 RID: 87705 RVA: 0x00675E98 File Offset: 0x00674298
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Skill_Shanjidilei/Skill_shanjidilei_Event_PVE");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Condition_bt_Monster_AI_Skill_Shanjidilei_Skill_shanjidilei_Event_PVE_node1 condition_bt_Monster_AI_Skill_Shanjidilei_Skill_shanjidilei_Event_PVE_node = new Condition_bt_Monster_AI_Skill_Shanjidilei_Skill_shanjidilei_Event_PVE_node1();
			condition_bt_Monster_AI_Skill_Shanjidilei_Skill_shanjidilei_Event_PVE_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Skill_Shanjidilei_Skill_shanjidilei_Event_PVE_node.SetId(1);
			sequence.AddChild(condition_bt_Monster_AI_Skill_Shanjidilei_Skill_shanjidilei_Event_PVE_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Skill_Shanjidilei_Skill_shanjidilei_Event_PVE_node.HasEvents());
			Condition_bt_Monster_AI_Skill_Shanjidilei_Skill_shanjidilei_Event_PVE_node3 condition_bt_Monster_AI_Skill_Shanjidilei_Skill_shanjidilei_Event_PVE_node2 = new Condition_bt_Monster_AI_Skill_Shanjidilei_Skill_shanjidilei_Event_PVE_node3();
			condition_bt_Monster_AI_Skill_Shanjidilei_Skill_shanjidilei_Event_PVE_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Skill_Shanjidilei_Skill_shanjidilei_Event_PVE_node2.SetId(3);
			sequence.AddChild(condition_bt_Monster_AI_Skill_Shanjidilei_Skill_shanjidilei_Event_PVE_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Skill_Shanjidilei_Skill_shanjidilei_Event_PVE_node2.HasEvents());
			Action_bt_Monster_AI_Skill_Shanjidilei_Skill_shanjidilei_Event_PVE_node2 action_bt_Monster_AI_Skill_Shanjidilei_Skill_shanjidilei_Event_PVE_node = new Action_bt_Monster_AI_Skill_Shanjidilei_Skill_shanjidilei_Event_PVE_node2();
			action_bt_Monster_AI_Skill_Shanjidilei_Skill_shanjidilei_Event_PVE_node.SetClassNameString("Action");
			action_bt_Monster_AI_Skill_Shanjidilei_Skill_shanjidilei_Event_PVE_node.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_Skill_Shanjidilei_Skill_shanjidilei_Event_PVE_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Skill_Shanjidilei_Skill_shanjidilei_Event_PVE_node.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
