#ifndef __SOCIALINFO_H__
#define __SOCIALINFO_H__

#include <string>

namespace NLogic {

class SocialInfo {

public:
	// ?��?�� 초�?? 차단 ?���?.
	enum class EnumInviteState : int {
		__NONE__ = -1,

		ALL_BLOCK,					// 0 : 모두 차단,
		DUNGEON_ON,				// 1 : ?��?�� 초�?? ON
		PVP_ON,					// 2 : PVP 초�?? ON
		DUNGEON_PVP_ON,			// 3 : (1+2) : ?��?�� 초�?? ON, PVP 초�?? ON
		BATTLE_ROYAL_ON,			// 4 : 배�??로얄 초�?? ON
		DUNGEON_BATTLE_ROYAL_ON,	// 5 (1+4) : ?��?�� 초�?? ON, 배�??로얄 ON
		PVP_BATTLE_ROYAL_ON,		// 6 (2+4) : PVP 초�?? ON, 배�??로얄 초�?? ON
		ALL_ON,					// 7 (1+2+4) : 모두 초�?? �??��

		__MAX__,
	};

	struct Data
	{
		uint32_t		_heart_count;
		int				_heart_blocked;
		int				_invite_blocked;
		int				_profile_opened;
		int				_gender;
		int				_isGenderOpen;	// ?���? 공개 ?���? ( 1: open, 0 : block)
		std::string		_birthday;
		int				_isBirthdayOpen;	// ?��?�� 공개 ?���?.

		Data() : _heart_count(0), _heart_blocked(0), _invite_blocked(7), _profile_opened(1), _gender(0), _isGenderOpen(1), _isBirthdayOpen(1) {}
		void Clear()
		{
			_heart_count = 0;
			_heart_blocked = 0;
			_invite_blocked = 7;
			_profile_opened = 1;
			_gender = 0;
			_isGenderOpen = 1;
			_birthday.clear();
			_isBirthdayOpen = 1;
		}
	};

public:
	SocialInfo();
	virtual ~SocialInfo();

	void Initialize();
	void Finalize();

	Data * GetData() { return _data; }

private:
	Data * _data;
};

} // namespace NLogic
#endif // __SOCIALINFO_H__
