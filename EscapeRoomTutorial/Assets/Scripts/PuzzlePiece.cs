using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PuzzlePiece : MonoBehaviour, IPointerClickHandler
{

    private GameObject puzzle;
    private Image changeSprite;

    // Start is called before the first frame update
    void Start()
    {
        puzzle = GameObject.Find("Puzzle");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (puzzle.GetComponent<Puzzle>().IsCompleted == true)
            return;

        var puzzlePieces = FindObjectsOfType<PuzzlePiece>();

        foreach (PuzzlePiece puzzlePiece in puzzlePieces)
        {
            //tentar entender o código abaixo (video sobre o puzzle, minuto 30
            if (int.Parse(this.gameObject.name.ToString().Substring(this.gameObject.name.Length - 1)) == int.Parse((puzzlePiece.gameObject.name.ToString().Substring(puzzlePiece.gameObject.name.Length - 1))) + 1
              ||
              int.Parse(this.gameObject.name.ToString().Substring(this.gameObject.name.Length - 1)) == int.Parse((puzzlePiece.gameObject.name.ToString().Substring(puzzlePiece.gameObject.name.Length - 1))) - 1
              ||
              int.Parse(this.gameObject.name.ToString().Substring(this.gameObject.name.Length - 1)) == int.Parse((puzzlePiece.gameObject.name.ToString().Substring(puzzlePiece.gameObject.name.Length - 1))) + 3
              ||
              int.Parse(this.gameObject.name.ToString().Substring(this.gameObject.name.Length - 1)) == int.Parse((puzzlePiece.gameObject.name.ToString().Substring(puzzlePiece.gameObject.name.Length - 1))) - 3)
            {
                if (puzzlePiece.gameObject.GetComponent<Image>().sprite.name == "empty_item8")
                {
                    changeSprite = puzzlePiece.GetComponent<Image>();
                    ChangeSprite(GetComponent<Image>(), changeSprite);

                }


            }



        }
    }

    void ChangeSprite(Image firstSprite, Image secondSprite)
    {
        Sprite temp = firstSprite.sprite;
        firstSprite.sprite = secondSprite.sprite;
        secondSprite.sprite = temp;

    }

  
}
