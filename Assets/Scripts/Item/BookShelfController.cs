using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    public class BookShelfController : ItemBase
    {
        [SerializeField] private GameObject booksInShelf;
        [SerializeField] private GameObject scatteredBooks;

        private void Update()
        {
       
        }
        public override void Use()
        {
            booksInShelf.SetActive(false);
            scatteredBooks.SetActive(true);
        }
    }
}