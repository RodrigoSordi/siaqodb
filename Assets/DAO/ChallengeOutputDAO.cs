using UnityEngine;
using System.Collections;

public class ChallengeOutputDAO : ParseDAO <ChallengeOutput> {

	public static readonly string KIDS_NAME_FIRST_LETTER =							 				"KIDS_NAME_FIRST_LETTER";
	public static readonly string IDENTIFY_LETTERS_BY_NAME = 										"IDENTIFY_LETTERS_BY_NAME";
	public static readonly string MATCH_FIRST_SYLLABLE_USING_DIFFERENT_CV_LETTERS = 				"MATCH_FIRST_SYLLABLE_USING_DIFFERENT_CV_LETTERS";
	public static readonly string MATCH_LAST_SYLLABLE = 											"MATCH_LAST_SYLLABLE";
	public static readonly string KIDS_NAME_LAST_LETTER = 											"KIDS_NAME_LAST_LETTER";
	public static readonly string IDENTIFY_OBJECTS_TTS_FIRST_LETTER = 								"IDENTIFY_OBJECTS_TTS_FIRST_LETTER";
	public static readonly string IDENTIFY_OBJECTS_FIRST_LETTER =									"IDENTIFY_OBJECTS_FIRST_LETTER";
	public static readonly string NAME_RECOGNITION_UNSCRAMBLE_ONLY_FIRST_AND_LAST_LETTERS = 		"NAME_RECOGNITION_UNSCRAMBLE_ONLY_FIRST_AND_LAST_LETTERS";
	public static readonly string RHYMING_IMAGES_WITH_IMAGES =										"RHYMING_IMAGES_WITH_IMAGES";
	public static readonly string PASSARO_GULOSO_GAME =												"PASSARO_GULOSO_GAME";
	public static readonly string FIND_MISSING_LETTER_IN_CHILDS_NAME = 								"FIND_MISSING_LETTER_IN_CHILDS_NAME";
	public static readonly string FIND_MISSING_LETTER_IN_OBJECTS_NAME =								"FIND_MISSING_LETTER_IN_OBJECTS_NAME";
	public static readonly string RHYMING_SOUNDS_WITH_WORDS =										"RHYMING_SOUNDS_WITH_WORDS";
	public static readonly string ORGANIZING_SYLLABLES_2_LETTERS_MORE_SYLLABLES_THAN_NECESSARY =	"ORGANIZING_SYLLABLES_2_LETTERS_MORE_SYLLABLES_THAN_NECESSARY";
	public static readonly string UNSCRAMPLING_SYLLABLES_3_LETTERS =								"UNSCRAMPLING_SYLLABLES_3_LETTERS";
	public static readonly string MATCH_WORDS_WITH_OBJECTS_SIMILAR_SPELLING_WORDS =					"MATCH_WORDS_WITH_OBJECTS_SIMILAR_SPELLING_WORDS";
	public static readonly string READ_WORD_FIND_OBJECT =											"READ_WORD_FIND_OBJECT";
	public static readonly string WHAT_RHYME_WITH_THIS_WORD =										"WHAT_RHYME_WITH_THIS_WORD";
	public static readonly string OBJECT_FIND_WORD =												"OBJECT_FIND_WORD";
	public static readonly string ADD_LETTER_TO_CHANGE_WORD_TO_WORD_IN_THE_SIGN =					"ADD_LETTER_TO_CHANGE_WORD_TO_WORD_IN_THE_SIGN";
	public static readonly string WRITE_WORD_IN_THE_SIGN_ONLY_NEEDED_LETTERS_AVAILABLE =			"WRITE_WORD_IN_THE_SIGN_ONLY_NEEDED_LETTERS_AVAILABLE";
	public static readonly string WRITE_WORD_IN_THE_SIGN_MORE_LETTERS_THAN_NEEDED_AVAILABLE =		"WRITE_WORD_IN_THE_SIGN_MORE_LETTERS_THAN_NEEDED_AVAILABLE";
	public static readonly string WRITE_WORD_IN_THE_SIGN_KEYBOARD =									"WRITE_WORD_IN_THE_SIGN_KEYBOARD";

	public ChallengeOutputDAO () {
		LIMIT = 1000;
	}

}
