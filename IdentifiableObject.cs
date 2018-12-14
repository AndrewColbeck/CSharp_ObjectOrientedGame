// Task 2.2P - IdentifiableObject class by Andrew Colbeck © 2018, all rights reserved.
// This Class creates a list of identifiable objects which can be altered,
// added to, and searched during gameplay in the Swin-Adventure case study.
  
using System;
using System.Collections.Generic;

namespace SwinAdventure {
    public class IdentifiableObject {
        // --------------------
        // LOCAL VARIABLES:
        // --------------------
        private List<string> _identifiers = new List<string>();
        private bool listIsEmpty = true;
        private string _firstid;
        
        // ---------------------
        // CONSTRUCTOR:
        // ---------------------
        public IdentifiableObject(string[] idents) {
            for (int i = 0; i < idents.Length; i++) {
                AddIdentifier(idents[i]);
            }
        }
        
        // ----------------------
        // PROPERTIES:
        // ----------------------
        // A 'Read Only' <<Properties>> accessor for _firstid:
        public string FirstId {
            get { return _firstid; }
        }

        // ----------------------
        // METHODS:
        // ----------------------
        // AreYou checks if the passed string exists in the _identifiers list:
        public bool AreYou(string id) {
            // For loop transverses _identifiers list, and converts id string
            // to lower case for comparison: 
            for (int i = 0; i < _identifiers.Count; i++) {
                if (id.ToLower() == _identifiers[i]) {
                    return true;
                }
            }
            
            // If no match is found, return false:
            return false;
        }

        // AddIdentifier converts a passed string to lower case and stores it 
        // in _identifiers list:
        public void AddIdentifier(string id) {
            id = id.ToLower();
            
            // if the list is empty, assign the first id to _firstid:
            if (listIsEmpty) {
                _firstid = id;
                listIsEmpty = false;
            }
            
            _identifiers.Add(id);
        }
    }
}